using CarBook.DTO.StatisticDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.ViewComponents.DefaultViewComponents
{
    public class _DefaultStatisticsComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            #region carCount
            var carCount = await GenericApiProvider<ResultStatisticDTO>.GetStatisticAsync("Statistic", "GetCarCount");
            if (carCount == null)
            {
                ViewBag.carCount = 0;
            }
            else
            {
                ViewBag.carCount = carCount.CarCount;
            }
            #endregion

            #region locationCount
            var locationCount = await GenericApiProvider<ResultStatisticDTO>.GetStatisticAsync("Statistic", "GetLocationCount");
            if (locationCount == null)
            {
                ViewBag.locationCount = 0;
            }
            else
            {
                ViewBag.locationCount = locationCount.LocationCount;
            }
            #endregion

            #region brandCount
            var brandCount = await GenericApiProvider<ResultStatisticDTO>.GetStatisticAsync("Statistic", "GetBrandCount");
            if (brandCount == null)
            {
                ViewBag.brandCount = 0;
            }
            else
            {
                ViewBag.brandCount = brandCount.BrandCount;
            }
            #endregion


            return View();
        }
    }
}
