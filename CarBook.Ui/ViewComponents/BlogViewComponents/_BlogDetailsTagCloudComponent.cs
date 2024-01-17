using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsTagCloudComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
