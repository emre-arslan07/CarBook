using AspNetCoreHero.ToastNotification.Abstractions;
using CarBook.DTO.BannerDTOs;
using CarBook.DTO.CommentDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminComment")]
    public class AdminCommentController : Controller
    {
        private readonly INotyfService _otyfService;

        public AdminCommentController(INotyfService otyfService)
        {
            _otyfService = otyfService;
        }

        [Route("Index/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            return View(await GenericApiProvider<ResultCommentDTO>.GetListAsyncById("Comment", "GetCommentsByBlogId", id));
        }

        [Route("RemoveComment/{id}")]
        public async Task<IActionResult> RemoveComment(int id)
        {
            if (await GenericApiProvider<bool>.DeleteTentityAsync("Comment", "RemoveComment", id) == true)
            {
                return RedirectToAction("Index", "AdminBlog", new { area = "Admin" });
            }
            else
            {
                return RedirectToAction("Index", "AdminComment", new { area = "Admin" });
            }
        }
    }
}
