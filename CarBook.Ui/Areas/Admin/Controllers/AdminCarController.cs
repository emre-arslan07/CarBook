using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Notyf;
using CarBook.DTO.BrandDTOs;
using CarBook.DTO.CarDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarBook.Ui.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCar")]
    public class AdminCarController : Controller
    {
        private readonly INotyfService _otyfService;

        public AdminCarController(INotyfService otyfService)
        {
            _otyfService = otyfService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            return View(await GenericApiProvider<ResultCarWithBrandDTO>.GetListAsync("Car", "GetCarWithBrand"));
        }

        [HttpGet]
        [Route("CreateCar")]
        public async Task<IActionResult> CreateCar()
        {
            ViewBag.Brands =await GetbrandValues();
            return View();
        }

        private async Task<List<SelectListItem>>  GetbrandValues()
        {
            List<SelectListItem> brandValues = (from x in await GenericApiProvider<ResultBrandDTO>.GetListAsync("Brand", "BrandList")
                                                select new SelectListItem
                                                {
                                                    Text = x.Name,
                                                    Value = x.Id.ToString()
                                                }).ToList();
            return brandValues;
        }

        [HttpPost]
        [Route("CreateCar")]
        public async Task<IActionResult> CreateCar(ResultCreateCarDTO resultCreateCarDTO)
        {
            if (await GenericApiProvider<ResultCreateCarDTO>.AddTentityAsync("Car", "CreateCar", resultCreateCarDTO) == true)
            {
                _otyfService.Success("Ekleme işlemi başarılı", 3);
                return RedirectToAction("Index", "AdminCar");
            }
            else
            {
                _otyfService.Error("Ekleme işlemi başarısız", 3);
                return RedirectToAction("CreateCar", "AdminCar");
            }
        }

        [Route("RemoveCar/{id}")]
        public async Task<IActionResult> RemoveCar(int id)
        {
            if (await GenericApiProvider<bool>.DeleteTentityAsync("Car","RemoveCar",id)==true)
            {
                return RedirectToAction("Index", "AdminCar", new { area = "Admin" });
            }
            else
            {
                return RedirectToAction("Index", "AdminCar", new { area = "Admin" });
            }
        }

        [HttpGet]
        [Route("UpdateCar/{id}")]
        public async Task<IActionResult> UpdateCar(int id)
        {
            ViewBag.Brands = await GetbrandValues();
            return View(await GenericApiProvider<ResultUpdateCarDTO>.GetAsyncById("Car","GetCar",id));
        }

        [HttpPost]
        [Route("UpdateCar/{id}")]
        public async Task<IActionResult> UpdateCar(ResultUpdateCarDTO resultUpdateCarDTO)
        {
            if (await GenericApiProvider<ResultUpdateCarDTO>.UpdateTentityAsync("Car", "UpdateCar", resultUpdateCarDTO) == true)
            {
                _otyfService.Success("Güncelleme işlemi başarılı", 3);
                return RedirectToAction("Index", "AdminCar", new { area = "Admin" });
            }
            else
            {
                _otyfService.Error("Güncelleme işlemi başarısız", 3);
                return RedirectToAction("UpdateCar", "AdminCar", new { area = "Admin" });
            }
        }

        




    }
}
