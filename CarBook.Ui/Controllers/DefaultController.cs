using CarBook.DTO.LocationDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarBook.Ui.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<SelectListItem> values=(from x in await GenericApiProvider<ResultLocationDTO>.GetListAsync("Location","LocationList")
                                         select new SelectListItem
                                         {
                                             Text=x.Name,
                                             Value=x.Id.ToString()
                                         }).ToList();
            ViewBag.Locations=values;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string Id,string book_pick_date,string book_off_date,string time_pick,string time_off)
        {
            TempData["Id"] = Id;
            TempData["bookpickdate"] = book_pick_date;
            TempData["bookoffdate"] = book_off_date;
            TempData["timepick"] = time_pick;
            TempData["timeoff"] = time_off;
            return RedirectToAction("Index","RentACarList");
        }
    }
}
