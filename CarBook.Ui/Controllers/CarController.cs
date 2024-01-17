using CarBook.DTO.CarDTOs;
using CarBook.DTO.CarPricingDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.Controllers
{
    public class CarController : Controller
    {
        public async  Task<IActionResult> Index()
        {
            ViewBag.v1 = "Arabalar";
            ViewBag.v2 = "Araçlarımız";
            return View(await GenericApiProvider<ResultCarPricingWithCarDTO>.GetListAsync("CarPricing", "GetCarPricingWithCarList")); 
        }
    }
}
