using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminStatistic")]
    public class AdminStatisticController : Controller
    {
        [Route("Index")]        //carCount,locationCount,locationCountRandom,authorCount,authorCountRandom,blogCount,blogCountRandom,brandCount,brandCountRandom,avgRentPriceForDaily,avgRentPriceForDailyRandom,avgRentPriceForWeekly,avgRentPriceForWeeklyRandom,avgRentPriceForMonthly,avgRentPriceForMonthlyRandom,carCountByTranmissionIsAuto,carCountByTranmissionIsAutoRandom,brandNameByMaxCar,brandNameByMaxCarRandom,blogTitleByMaxBlogComment,blogTitleByMaxBlogCommentRandom,carCountByKmSmallerThen1000,carCountByKmSmallerThen1000Random,carCountByFuelGasolineOrDiesel,carCountByFuelGasolineOrDieselRandom,carCountByFuelElectric,carCountByFuelElectricRandom,carBrandAndModelByRentPriceDailyMax,carBrandAndModelByRentPriceDailyMaxRandom,carBrandAndModelByRentPriceDailyMin,carBrandAndModelByRentPriceDailyMinRandom
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
