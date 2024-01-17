using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.ViewComponents.CommentViewComponents
{
    public class _CommentListByBlogComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
