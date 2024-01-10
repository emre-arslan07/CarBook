using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.ViewComponents.UILayoutViewComponents
{
    public class _ScriptUILayoutComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
