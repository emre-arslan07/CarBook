using CarBook.DTO.CarPricingDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.Areas.Admin.ViewComponents.AdminDashboardComponents
{
    public class _AdminDashboardCarPricingComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await GenericApiProvider<ResultCarPricingWithModelBrandDTO>.GetListAsync("CarPricing", "GetCarPricingWithTimePeriodList"));
        }
    }
}
