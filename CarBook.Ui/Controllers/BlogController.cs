using CarBook.DTO.BlogDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.Controllers
{
    public class BlogController : Controller
    {
        public async  Task<IActionResult> Index()
        {
            ViewBag.v1 = "Bloglar";
            ViewBag.v2 = "Yazarlarımızın Blogları";
            return View(await GenericApiProvider<ResultBlogWithAuthor>.GetListAsync("Blog", "BlogsWithAuthor"));
        }

        [HttpGet]
        public async Task<IActionResult> BlogDetail(int id)
        {
            ViewBag.v1 = "Bloglar";
            ViewBag.v2 = "Blog Detayı Ve Yorumlar ";
            return View();
        }
    }
}
