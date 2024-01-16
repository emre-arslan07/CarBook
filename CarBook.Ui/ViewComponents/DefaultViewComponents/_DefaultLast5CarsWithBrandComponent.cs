using CarBook.DTO.CarDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.ViewComponents.DefaultViewComponents
{
    public class _DefaultLast5CarsWithBrandComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await GenericApiProvider<ResultLast5CarsWithBrandDTO>.GetListAsync("Car", "Last5CarsListWithBrand"));
        }
    }
}
