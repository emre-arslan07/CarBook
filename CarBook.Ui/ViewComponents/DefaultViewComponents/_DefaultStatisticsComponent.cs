using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.ViewComponents.DefaultViewComponents
{
    public class _DefaultStatisticsComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
