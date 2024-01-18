using CarBook.DTO.TagCloudDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.ViewComponents.BlogViewComponents
{
    public class _BlogDetailCloudTagByBlogComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return View(await GenericApiProvider<ResultTagCloudByBlogIdDTO>.GetListAsyncById("TagCloud", "TagCloudByBlogId",id));
        }
    }
}
