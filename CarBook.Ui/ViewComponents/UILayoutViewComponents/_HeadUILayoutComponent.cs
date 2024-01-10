using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.ViewComponents.UILayoutViewComponents
{
    public class _HeadUILayoutComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
