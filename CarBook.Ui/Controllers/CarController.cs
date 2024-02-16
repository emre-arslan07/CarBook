using CarBook.DTO.CarDTOs;
using CarBook.DTO.CarPricingDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.Controllers
{
    [AllowAnonymous]
    public class CarController : Controller
    {
        [HttpGet]
        public async  Task<IActionResult> Index() 
		{
            ViewBag.v1 = "Arabalar";
            ViewBag.v2 = "Araçlarımız";
            return View(await GenericApiProvider<ResultCarPricingWithCarDTO>.GetListAsync("CarPricing", "GetCarPricingWithCarList")); 
        }
		[HttpGet]
		public async Task<IActionResult> CarDetail(int id)
        {
			ViewBag.v1 = "Arabalar";
			ViewBag.v2 = "Araç Detayları";
            ViewBag.Id=id;
			return View();
        }
    }
}
