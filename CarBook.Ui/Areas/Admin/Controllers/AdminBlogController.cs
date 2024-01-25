using AspNetCoreHero.ToastNotification.Abstractions;
using CarBook.DTO.BlogDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminBlog")]
    public class AdminBlogController : Controller
    {
        private readonly INotyfService _otyfService;

        public AdminBlogController(INotyfService otyfService)
        {
            _otyfService = otyfService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            return View(await GenericApiProvider<ResultBlogWithAuthor>.GetListAsync("Blog", "BlogsWithAuthor"));
        }


        [Route("RemoveBlog/{id}")]
        public async Task<IActionResult> RemoveBlog(int id)
        {
            if (await GenericApiProvider<bool>.DeleteTentityAsync("Blog", "RemoveBlog", id) == true)
            {
                return RedirectToAction("Index", "AdminBlog", new { area = "Admin" });
            }
            else
            {
                return RedirectToAction("Index", "AdminBlog", new { area = "Admin" });
            }
        }

    }
}
