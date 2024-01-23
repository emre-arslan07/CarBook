using AspNetCoreHero.ToastNotification.Abstractions;
using CarBook.DTO.CarDTOs;
using CarBook.DTO.FeatureDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminFeature")]
    public class AdminFeatureController : Controller
    {
        private readonly INotyfService _otyfService;

        public AdminFeatureController(INotyfService otyfService)
        {
            _otyfService = otyfService;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            return View(await GenericApiProvider<ResultFeatureDTO>.GetListAsync("Feature","FeatureList"));
        }

        [HttpGet]
        [Route("CreateFeature")]
        public async Task<IActionResult> CreateFeature()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateFeature")]
        public async Task<IActionResult> CreateFeature(ResultCreateFeatureDTO resultCreateFeatureDTO )
        {
            if (await GenericApiProvider<ResultCreateFeatureDTO>.AddTentityAsync("Feature", "CreateFeature", resultCreateFeatureDTO) == true)
            {
                _otyfService.Success("Ekleme işlemi başarılı", 3);
                return RedirectToAction("Index", "AdminFeature", new { area = "Admin" });
            }
            else
            {
                _otyfService.Error("Ekleme işlemi başarısız", 3);
                return RedirectToAction("CreateFeature", "AdminFeature", new { area = "Admin" });
            }
        }

        [Route("RemoveFeature/{id}")]
        public async Task<IActionResult> RemoveFeature(int id)
        {
            if (await GenericApiProvider<bool>.DeleteTentityAsync("Feature", "RemoveFeature", id) == true)
            {
                return RedirectToAction("Index", "AdminFeature", new { area = "Admin" });
            }
            else
            {
                return RedirectToAction("Index", "AdminFeature", new { area = "Admin" });
            }
        }


        [HttpGet]
        [Route("UpdateFeature/{id}")]
        public async Task<IActionResult> UpdateFeature(int id)
        {
            return View(await GenericApiProvider<ResultUpdateFeatureDTO>.GetAsyncById("Feature", "GetFeature", id));
        }

        [HttpPost]
        [Route("UpdateFeature/{id}")]
        public async Task<IActionResult> UpdateFeature(ResultUpdateFeatureDTO  resultUpdateFeatureDTO)
        {
            if (await GenericApiProvider<ResultUpdateFeatureDTO>.UpdateTentityAsync("Feature", "UpdateFeature", resultUpdateFeatureDTO) == true)
            {
                _otyfService.Success("Güncelleme işlemi başarılı", 3);
                return RedirectToAction("Index", "AdminFeature", new { area = "Admin" });
            }
            else
            {
                _otyfService.Error("Güncelleme işlemi başarısız", 3);
                return RedirectToAction("UpdateFeature", "AdminFeature", new { area = "Admin" });
            }
        }
    }
}
