using CarBook.DTO.BlogDTOs;
using CarBook.DTO.CommentDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.Controllers
{
    [AllowAnonymous]

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
            ViewBag.Id=id;
            return View();
        }


        [HttpGet]
        public async Task<PartialViewResult> AddComment(int id)
        {
            ViewBag.Id = id;

            return PartialView();  
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(ResultCreateCommentDTO resultCreateCommentDTO) 
        {
            if (resultCreateCommentDTO != null)
            {
                if (await GenericApiProvider<ResultCreateCommentDTO>.AddTentityAsync("Comment", "CreateComment", resultCreateCommentDTO) == true)
                {
                    return RedirectToAction("Index","Default");
                }
                else
                {
                    return View(resultCreateCommentDTO);
                }
            }
            return View();
        }
    }
}
