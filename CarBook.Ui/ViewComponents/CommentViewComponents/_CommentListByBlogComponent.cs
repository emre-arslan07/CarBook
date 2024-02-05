using CarBook.DTO.CommentDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.ViewComponents.CommentViewComponents
{
    public class _CommentListByBlogComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {

            return View(await GenericApiProvider<ResultCommentDTO>.GetListAsyncById("Comment", "GetCommentsByBlogId",id));
        }
    }
}
