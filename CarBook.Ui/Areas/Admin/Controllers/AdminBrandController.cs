using AspNetCoreHero.ToastNotification.Abstractions;
using CarBook.DTO.BrandDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminBrand")]
    public class AdminBrandController : Controller
    {
        private readonly INotyfService _otyfService;

        public AdminBrandController(INotyfService otyfService)
        {
            _otyfService = otyfService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            return View(await GenericApiProvider<ResultBrandDTO>.GetListAsync("Brand", "BrandList"));
        }

        [HttpGet]
        [Route("CreateBrand")]
        public async Task<IActionResult> CreateBrand()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateBrand")]
        public async Task<IActionResult> CreateBrand(ResultCreateBrandDTO resultCreateBrandDTO)
        {
            if (await GenericApiProvider<ResultCreateBrandDTO>.AddTentityAsync("Brand", "CreateBrand", resultCreateBrandDTO) == true)
            {
                _otyfService.Success("Ekleme işlemi başarılı", 3);
                return RedirectToAction("Index", "AdminBrand", new { area = "Admin" });
            }
            else
            {
                _otyfService.Error("Ekleme işlemi başarısız", 3);
                return RedirectToAction("CreateBrand", "AdminBrand", new { area = "Admin" });
            }
        }

        [Route("RemoveBrand/{id}")]
        public async Task<IActionResult> RemoveBrand(int id)
        {
            if (await GenericApiProvider<bool>.DeleteTentityAsync("Brand", "RemoveBrand", id) == true)
            {
                return RedirectToAction("Index", "AdminBrand", new { area = "Admin" });
            }
            else
            {
                return RedirectToAction("Index", "AdminBrand", new { area = "Admin" });
            }
        }


        [HttpGet]
        [Route("UpdateBrand/{id}")]
        public async Task<IActionResult> UpdateBrand(int id)
        {
            return View(await GenericApiProvider<ResultUpdateBrandDTO>.GetAsyncById("Brand", "GetBrand", id));
        }

        [HttpPost]
        [Route("UpdateBrand/{id}")]
        public async Task<IActionResult> UpdateBrand(ResultUpdateBrandDTO resultUpdateBrandDTO)
        {
            if (await GenericApiProvider<ResultUpdateBrandDTO>.UpdateTentityAsync("Brand", "UpdateBrand", resultUpdateBrandDTO) == true)
            {
                _otyfService.Success("Güncelleme işlemi başarılı", 3);
                return RedirectToAction("Index", "AdminBrand", new { area = "Admin" });
            }
            else
            {
                _otyfService.Error("Güncelleme işlemi başarısız", 3);
                return RedirectToAction("UpdateBrand", "AdminBrand", new { area = "Admin" });
            }
        }
    }
}
