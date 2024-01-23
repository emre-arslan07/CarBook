using AspNetCoreHero.ToastNotification.Abstractions;
using CarBook.DTO.AboutDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminAbout")]
    public class AdminAboutController : Controller
    {
        private readonly INotyfService _otyfService;

        public AdminAboutController(INotyfService otyfService)
        {
            _otyfService = otyfService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            return View(await GenericApiProvider<ResultAboutDTO>.GetListAsync("About", "AboutList"));
        }

        [HttpGet]
        [Route("CreateAbout")]
        public async Task<IActionResult> CreateAbout()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateAbout")]
        public async Task<IActionResult> CreateAbout(ResultCreateAboutDTO resultCreateAboutDTO)
        {
            if (await GenericApiProvider<ResultCreateAboutDTO>.AddTentityAsync("About", "CreateAbout", resultCreateAboutDTO) == true)
            {
                _otyfService.Success("Ekleme işlemi başarılı", 3);
                return RedirectToAction("Index", "AdminAbout", new { area = "Admin" });
            }
            else
            {
                _otyfService.Error("Ekleme işlemi başarısız", 3);
                return RedirectToAction("CreateAbout", "AdminAbout", new { area = "Admin" });
            }
        }

        [Route("RemoveAbout/{id}")]
        public async Task<IActionResult> RemoveAbout(int id)
        {
            if (await GenericApiProvider<bool>.DeleteTentityAsync("About", "RemoveAbout", id) == true)
            {
                return RedirectToAction("Index", "AdminAbout", new { area = "Admin" });
            }
            else
            {
                return RedirectToAction("Index", "AdminAbout", new { area = "Admin" });
            }
        }


        [HttpGet]
        [Route("UpdateAbout/{id}")]
        public async Task<IActionResult> UpdateAbout(int id)
        {
            return View(await GenericApiProvider<ResultUpdateAboutDTO>.GetAsyncById("About", "GetAbout", id));
        }

        [HttpPost]
        [Route("UpdateAbout/{id}")]
        public async Task<IActionResult> UpdateAbout(ResultUpdateAboutDTO resultUpdateAboutDTO)
        {
            if (await GenericApiProvider<ResultUpdateAboutDTO>.UpdateTentityAsync("About", "UpdateAbout", resultUpdateAboutDTO) == true)
            {
                _otyfService.Success("Güncelleme işlemi başarılı", 3);
                return RedirectToAction("Index", "AdminAbout", new { area = "Admin" });
            }
            else
            {
                _otyfService.Error("Güncelleme işlemi başarısız", 3);
                return RedirectToAction("UpdateAbout", "AdminAbout", new { area = "Admin" });
            }
        }
    }
}
