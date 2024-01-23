using AspNetCoreHero.ToastNotification.Abstractions;
using CarBook.DTO.BannerDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminBanner")]
    public class AdminBannerController : Controller
    {
        private readonly INotyfService _otyfService;

        public AdminBannerController(INotyfService otyfService)
        {
            _otyfService = otyfService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            return View(await GenericApiProvider<ResultBannerDTO>.GetListAsync("Banner", "BannerList"));
        }

        [HttpGet]
        [Route("CreateBanner")]
        public async Task<IActionResult> CreateBanner()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateBanner")]
        public async Task<IActionResult> CreateBanner(ResultCreateBannerDTO resultCreateBannerDTO)
        {
            if (await GenericApiProvider<ResultCreateBannerDTO>.AddTentityAsync("Banner", "CreateBanner", resultCreateBannerDTO) == true)
            {
                _otyfService.Success("Ekleme işlemi başarılı", 3);
                return RedirectToAction("Index", "AdminBanner", new { area = "Admin" });
            }
            else
            {
                _otyfService.Error("Ekleme işlemi başarısız", 3);
                return RedirectToAction("CreateBanner", "AdminBanner", new { area = "Admin" });
            }
        }

        [Route("RemoveBanner/{id}")]
        public async Task<IActionResult> RemoveBanner(int id)
        {
            if (await GenericApiProvider<bool>.DeleteTentityAsync("Banner", "RemoveBanner", id) == true)
            {
                return RedirectToAction("Index", "AdminBanner", new { area = "Admin" });
            }
            else
            {
                return RedirectToAction("Index", "AdminBanner", new { area = "Admin" });
            }
        }


        [HttpGet]
        [Route("UpdateBanner/{id}")]
        public async Task<IActionResult> UpdateBanner(int id)
        {
            return View(await GenericApiProvider<ResultUpdateBannerDTO>.GetAsyncById("Banner", "GetBanner", id));
        }

        [HttpPost]
        [Route("UpdateBanner/{id}")]
        public async Task<IActionResult> UpdateBanner(ResultUpdateBannerDTO resultUpdateBannerDTO)
        {
            if (await GenericApiProvider<ResultUpdateBannerDTO>.UpdateTentityAsync("Banner", "UpdateBanner", resultUpdateBannerDTO) == true)
            {
                _otyfService.Success("Güncelleme işlemi başarılı", 3);
                return RedirectToAction("Index", "AdminBanner", new { area = "Admin" });
            }
            else
            {
                _otyfService.Error("Güncelleme işlemi başarısız", 3);
                return RedirectToAction("UpdateBanner", "AdminBanner", new { area = "Admin" });
            }
        }
    }
}
