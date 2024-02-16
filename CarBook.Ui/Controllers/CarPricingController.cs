using CarBook.DTO.CarPricingDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.Controllers
{
    [AllowAnonymous]

    public class CarPricingController : Controller
    {
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Paketler";
            ViewBag.v2 = "Araç Fiyat Paketleri";
            return View(await GenericApiProvider<ResultCarPricingWithModelBrandDTO>.GetListAsync("CarPricing", "GetCarPricingWithTimePeriodList"));
        }
    }
}
