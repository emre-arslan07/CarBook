using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.Areas.Admin.ViewComponents.AdminLayoutComponents
{
    public class _AdminFooterComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
