using CarBook.DTO.StatisticDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Newtonsoft.Json;

namespace CarBook.Ui.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminStatistic")]
    public class AdminStatisticController : Controller
    {

        [Route("Index")]
        public async Task<IActionResult> Index()
        {

            #region carCount
            var carCount = await GenericApiProvider<ResultStatisticDTO>.GetStatisticAsync("Statistic", "GetCarCount");
            if (carCount==null)
            {
                ViewBag.carCount = 0;
                ViewBag.carCountRandom = RandomNumber();
            }
            else
            {
                ViewBag.carCount = carCount.CarCount;
                ViewBag.carCountRandom = RandomNumber();
            }
            #endregion

            #region locationCount
            var locationCount = await GenericApiProvider<ResultStatisticDTO>.GetStatisticAsync("Statistic", "GetLocationCount");
            if (locationCount==null)
            {
                ViewBag.locationCount = 0;
                ViewBag.locationCountRandom = RandomNumber();
            }
            else
            {
                ViewBag.locationCount = locationCount.LocationCount;
                ViewBag.locationCountRandom = RandomNumber();
            }
            #endregion

            #region authorCount
            var authorCount = await GenericApiProvider<ResultStatisticDTO>.GetStatisticAsync("Statistic", "GetAuthorCount");
            if (authorCount==null)
            {
                ViewBag.authorCount = 0;
                ViewBag.authorCountRandom = RandomNumber();
            }
            else
            {
                ViewBag.authorCount = authorCount.AuthorCount;
                ViewBag.authorCountRandom = RandomNumber();
            }
            #endregion

            #region blogCount
            var blogCount = await GenericApiProvider<ResultStatisticDTO>.GetStatisticAsync("Statistic", "GetBlogCount");
            if (blogCount==null)
            {
                ViewBag.blogCount = 0;
                ViewBag.blogCountRandom = RandomNumber();
            }
            else
            {
                ViewBag.blogCount = blogCount.BlogCount;
                ViewBag.blogCountRandom = RandomNumber();
            }
            #endregion

            #region brandCount
            var brandCount = await GenericApiProvider<ResultStatisticDTO>.GetStatisticAsync("Statistic", "GetBrandCount");
            if (brandCount==null)
            {
                ViewBag.brandCount = 0;
                ViewBag.brandCountRandom = RandomNumber();
            }
            else
            {
                ViewBag.brandCount = brandCount.BrandCount;
                ViewBag.brandCountRandom = RandomNumber();
            }
            #endregion

            #region avgRentPriceForDaily
            var avgRentPriceForDaily = await GenericApiProvider<ResultStatisticDTO>.GetStatisticAsync("Statistic", "GetAvgRentPriceForDaily");
            if (avgRentPriceForDaily == null)
            {
                ViewBag.avgRentPriceForDaily = 0;
                ViewBag.avgRentPriceForDailyRandom = RandomNumber();
            }
            else
            {
                ViewBag.avgRentPriceForDaily = avgRentPriceForDaily.AvgRentPriceForDaily.ToString("0.00");
                ViewBag.avgRentPriceForDailyRandom = RandomNumber();
            }
            #endregion

            #region avgRentPriceForWeekly
            var avgRentPriceForWeekly = await GenericApiProvider<ResultStatisticDTO>.GetStatisticAsync("Statistic", "GetAvgRentPriceForWeekly");
            if (avgRentPriceForWeekly == null)
            {
                ViewBag.avgRentPriceForWeekly = 0;
                ViewBag.avgRentPriceForWeeklyRandom = RandomNumber();
            }
            else
            {
                ViewBag.avgRentPriceForWeekly = avgRentPriceForWeekly.AvgRentPriceForWeekly.ToString("0.00");
                ViewBag.avgRentPriceForWeeklyRandom = RandomNumber();
            }
            #endregion

            #region avgRentPriceForMonthly
            var avgRentPriceForMonthly = await GenericApiProvider<ResultStatisticDTO>.GetStatisticAsync("Statistic", "GetAvgRentPriceForMonthly");
            if (avgRentPriceForMonthly==null)
            {
                ViewBag.avgRentPriceForMonthly = 0;
                ViewBag.avgRentPriceForMonthlyRandom = RandomNumber();
            }
            else
            {
            ViewBag.avgRentPriceForMonthly = avgRentPriceForMonthly.AvgRentPriceForMonthly.ToString("0.00");
            ViewBag.avgRentPriceForMonthlyRandom = RandomNumber();
            }
            #endregion

            #region carCountByTranmissionIsAuto
            var carCountByTranmissionIsAuto = await GenericApiProvider<ResultStatisticDTO>.GetStatisticAsync("Statistic", "GetCarCountByTranmissionIsAuto");
            if (carCountByTranmissionIsAuto == null)
            {
                ViewBag.carCountByTranmissionIsAuto = 0;
                ViewBag.carCountByTranmissionIsAutoRandom = RandomNumber();
            }
            else
            {
                ViewBag.carCountByTranmissionIsAuto = carCountByTranmissionIsAuto.CarCountByTranmissionIsAuto;
                ViewBag.carCountByTranmissionIsAutoRandom = RandomNumber(); 
            }
            #endregion

            #region carCountByKmSmallerThan1000
            var carCountByKmSmallerThan1000 = await GenericApiProvider<ResultStatisticDTO>.GetStatisticAsync("Statistic", "GetCarCountByKmSmallerThan1000");
            if (carCountByKmSmallerThan1000 == null)
            {
                ViewBag.carCountByKmSmallerThan1000 = 0;
                ViewBag.carCountByKmSmallerThan1000Random = RandomNumber();
            }
            else
            {
                ViewBag.carCountByKmSmallerThan1000 = carCountByKmSmallerThan1000.CarCountByKmSmallerThan1000;
                ViewBag.carCountByKmSmallerThan1000Random = RandomNumber();
            }
            #endregion


            #region carCountByFuelGasolineOrDiesel
            var carCountByFuelGasolineOrDiesel = await GenericApiProvider<ResultStatisticDTO>.GetStatisticAsync("Statistic", "GetCarCountByFuelGasolineOrDiesel");
            if (carCountByFuelGasolineOrDiesel == null)
            {
                ViewBag.carCountByFuelGasolineOrDiesel = 0;
                ViewBag.carCountByFuelGasolineOrDieselRandom = RandomNumber();
            }
            else
            {
                ViewBag.carCountByFuelGasolineOrDiesel = carCountByFuelGasolineOrDiesel.CarCountByFuelGasolineOrDiesel;
                ViewBag.carCountByFuelGasolineOrDieselRandom = RandomNumber();
            }
            #endregion  

            return View();
           
        }

        public int RandomNumber()
        {
            Random random = new Random();
            return random.Next(0, 101);
        }
    }
}
        //carCount,locationCount,locationCountRandom,authorCount,authorCountRandom,blogCount,blogCountRandom,brandCount,brandCountRandom,avgRentPriceForDaily,avgRentPriceForDailyRandom,avgRentPriceForWeekly,avgRentPriceForWeeklyRandom,avgRentPriceForMonthly,avgRentPriceForMonthlyRandom,carCountByTranmissionIsAuto,carCountByTranmissionIsAutoRandom,brandNameByMaxCar,brandNameByMaxCarRandom,blogTitleByMaxBlogComment,blogTitleByMaxBlogCommentRandom,carCountByKmSmallerThen1000,carCountByKmSmallerThen1000Random,carCountByFuelGasolineOrDiesel,carCountByFuelGasolineOrDieselRandom,carCountByFuelElectric,carCountByFuelElectricRandom,carBrandAndModelByRentPriceDailyMax,carBrandAndModelByRentPriceDailyMaxRandom,carBrandAndModelByRentPriceDailyMin,carBrandAndModelByRentPriceDailyMinRandom
