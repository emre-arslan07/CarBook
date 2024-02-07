using CarBook.DTO.StatisticDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.Areas.Admin.ViewComponents.AdminDashboardComponents
{
    public class _AdminDashboardStatisticsComponent:ViewComponent
    {
        public int RandomNumber()
        {
            Random random = new Random();
            return random.Next(0, 101);
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            #region carCount
            var carCount = await GenericApiProvider<ResultStatisticDTO>.GetStatisticAsync("Statistic", "GetCarCount");
            if (carCount == null)
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
            if (locationCount == null)
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

            #region brandCount
            var brandCount = await GenericApiProvider<ResultStatisticDTO>.GetStatisticAsync("Statistic", "GetBrandCount");
            if (brandCount == null)
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

            return View();
        }
    }
}
