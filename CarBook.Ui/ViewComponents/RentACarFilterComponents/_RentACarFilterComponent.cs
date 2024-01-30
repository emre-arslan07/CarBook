using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.ViewComponents.RentACarFilterComponents
{
    public class _RentACarFilterComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
