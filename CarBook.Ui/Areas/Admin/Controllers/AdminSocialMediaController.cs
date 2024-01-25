using AspNetCoreHero.ToastNotification.Abstractions;
using CarBook.DTO.ServiceDTOs;
using CarBook.DTO.SocialMediaDTO;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminSocialMedia")]
    public class AdminSocialMediaController : Controller
    {
        private readonly INotyfService _otyfService;

        public AdminSocialMediaController(INotyfService otyfService)
        {
            _otyfService = otyfService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            return View(await GenericApiProvider<ResultSocialMediaDTO>.GetListAsync("SocialMedia", "SocialMediaList"));
        }

        [HttpGet]
        [Route("CreateSocialMedia")]
        public async Task<IActionResult> CreateSocialMedia()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateSocialMedia")]
        public async Task<IActionResult> CreateSocialMedia(ResultCreateSocialMediaDTO resultCreateSocialMediaDTO )
        {
            if (await GenericApiProvider<ResultCreateSocialMediaDTO>.AddTentityAsync("SocialMedia", "CreateSocialMedia", resultCreateSocialMediaDTO) == true)
            {
                _otyfService.Success("Ekleme işlemi başarılı", 3);
                return RedirectToAction("Index", "AdminSocialMedia", new { area = "Admin" });
            }
            else
            {
                _otyfService.Error("Ekleme işlemi başarısız", 3);
                return RedirectToAction("CreateSocialMedia", "AdminSocialMedia", new { area = "Admin" });
            }
        }

        [Route("RemoveSocialMedia/{id}")]
        public async Task<IActionResult> RemoveSocialMedia(int id)
        {
            if (await GenericApiProvider<bool>.DeleteTentityAsync("SocialMedia", "RemoveSocialMedia", id) == true)
            {
                return RedirectToAction("Index", "AdminSocialMedia", new { area = "Admin" });
            }
            else
            {
                return RedirectToAction("Index", "AdminSocialMedia", new { area = "Admin" });
            }
        }


        [HttpGet]
        [Route("UpdateSocialMedia/{id}")]
        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            return View(await GenericApiProvider<ResultUpdateSocialMediaDTO>.GetAsyncById("SocialMedia", "GetSocialMedia", id));
        }

        [HttpPost]
        [Route("UpdateSocialMedia/{id}")]
        public async Task<IActionResult> UpdateSocialMedia(ResultUpdateSocialMediaDTO resultUpdateSocialMediaDTO)
        {
            if (await GenericApiProvider<ResultUpdateSocialMediaDTO>.UpdateTentityAsync("SocialMedia", "UpdateSocialMedia", resultUpdateSocialMediaDTO) == true)
            {
                _otyfService.Success("Güncelleme işlemi başarılı", 3);
                return RedirectToAction("Index", "AdminSocialMedia", new { area = "Admin" });
            }
            else
            {
                _otyfService.Error("Güncelleme işlemi başarısız", 3);
                return RedirectToAction("UpdateSocialMedia", "AdminSocialMedia", new { area = "Admin" });
            }
        }
    }
}
