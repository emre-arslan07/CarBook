using AspNetCoreHero.ToastNotification.Abstractions;
using CarBook.DTO.AuthorDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminAuthor")]
    public class AdminAuthorController : Controller
    {
        private readonly INotyfService _otyfService;

        public AdminAuthorController(INotyfService otyfService)
        {
            _otyfService = otyfService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            return View(await GenericApiProvider<ResultAuthorDTO>.GetListAsync("Author", "AuthorList"));
        }

        [HttpGet]
        [Route("CreateAuthor")]
        public async Task<IActionResult> CreateAuthor()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateAuthor")]
        public async Task<IActionResult> CreateAuthor(ResultCreateAuthorDTO resultCreateAuthorDTO)
        {
            if (await GenericApiProvider<ResultCreateAuthorDTO>.AddTentityAsync("Author", "CreateAuthor", resultCreateAuthorDTO) == true)
            {
                _otyfService.Success("Ekleme işlemi başarılı", 3);
                return RedirectToAction("Index", "AdminAuthor", new { area = "Admin" });
            }
            else
            {
                _otyfService.Error("Ekleme işlemi başarısız", 3);
                return RedirectToAction("CreateAuthor", "AdminAuthor", new { area = "Admin" });
            }
        }

        [Route("RemoveAuthor/{id}")]
        public async Task<IActionResult> RemoveAuthor(int id)
        {
            if (await GenericApiProvider<bool>.DeleteTentityAsync("Author", "RemoveAuthor", id) == true)
            {
                return RedirectToAction("Index", "AdminAuthor", new { area = "Admin" });
            }
            else
            {
                return RedirectToAction("Index", "AdminAuthor", new { area = "Admin" });
            }
        }


        [HttpGet]
        [Route("UpdateAuthor/{id}")]
        public async Task<IActionResult> UpdateAuthor(int id)
        {
            return View(await GenericApiProvider<ResultUpdateAuthorDTO>.GetAsyncById("Author", "GetAuthor", id));
        }

        [HttpPost]
        [Route("UpdateAuthor/{id}")]
        public async Task<IActionResult> UpdateAuthor(ResultUpdateAuthorDTO resultUpdateAuthorDTO)
        {
            if (await GenericApiProvider<ResultUpdateAuthorDTO>.UpdateTentityAsync("Author", "UpdateAuthor", resultUpdateAuthorDTO) == true)
            {
                _otyfService.Success("Güncelleme işlemi başarılı", 3);
                return RedirectToAction("Index", "AdminAuthor", new { area = "Admin" });
            }
            else
            {
                _otyfService.Error("Güncelleme işlemi başarısız", 3);
                return RedirectToAction("UpdateAuthor", "AdminAuthor", new { area = "Admin" });
            }
        }
    }
}
