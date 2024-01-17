using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsRecentBlogsComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
