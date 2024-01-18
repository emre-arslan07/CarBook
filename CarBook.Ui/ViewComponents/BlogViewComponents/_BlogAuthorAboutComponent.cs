using CarBook.DTO.BlogDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.ViewComponents.BlogViewComponents
{
    public class _BlogAuthorAboutComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return View(await GenericApiProvider<ResultAuthorByBlogIdDTO>.GetListAsyncById("Blog", "AuthorByBlogId", id));
        }
    }
}
