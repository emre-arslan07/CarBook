using CarBook.DTO.CarDTOs;
using CarBook.DTO.LocationDTOs;
using CarBook.DTO.ReservationDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarBook.Ui.Controllers
{
    public class ReservationController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.v1 = "Araç Kiralama";
            ViewBag.v2 = "Araç&Rezervasyon";
            var value = await GenericApiProvider<ResultCarWithBrandDTO>.GetAsyncById("Car", "GetCarWithBrandById", id);
            ViewBag.CarModelWithBrand= value.BrandName+" "+value.Model;
            ViewBag.Id = id;
            
            ViewBag.Location =await GetLocationValues();
            
            return View();
        }

        private async Task<List<SelectListItem>> GetLocationValues()
        {
            List<SelectListItem> locationValues = (from x in await GenericApiProvider<ResultLocationDTO>.GetListAsync("Location", "LocationList")
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.Id.ToString()
                                           }).ToList();
            return locationValues;
        }

        [HttpPost]
        public async Task<IActionResult> Index(ResultCreateReservationDTO resultCreateReservationDTO)
        {
            if (resultCreateReservationDTO != null) 
            {
                if (await GenericApiProvider<ResultCreateReservationDTO>.AddTentityAsync("Reservation","CreateReservation",resultCreateReservationDTO)==true)
                {
                    return RedirectToAction("Index", "Default");
                }
                else
                {
                    return View(resultCreateReservationDTO);
                }
            }

            return View();
        }
    }
}
