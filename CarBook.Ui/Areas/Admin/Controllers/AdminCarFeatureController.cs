using AspNetCoreHero.ToastNotification.Abstractions;
using CarBook.DTO.CarFeatureDTOs;
using CarBook.DTO.FeatureDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarBook.Ui.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCarFeature")]
    public class AdminCarFeatureController : Controller
    {
        private readonly INotyfService _otyfService;

        public AdminCarFeatureController(INotyfService otyfService)
        {
            _otyfService = otyfService;
        }

        [HttpGet]
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            return View(await GenericApiProvider<ResultCarFeaturesByCarIdDTO>.GetListAsyncById("CarFeature", "GetCarFeatureByCarId",id));
        }


        [HttpPost]
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(List<ResultCarFeaturesByCarIdDTO> resultCarFeaturesByCarIdDTOs)
        {
            foreach (var item in resultCarFeaturesByCarIdDTOs)
            {
                if (item.Available)
                {
                    if(await GenericApiProvider<bool>.UpdateWithIdAsync("CarFeature", "UpdateCarFeatureAvailableChangeToTrue",item.Id)==true)
                    {
                        _otyfService.Success("Güncelleme işlemi başarılı", 3);
                    }
                    else
                    {
                        _otyfService.Success("Güncelleme işlemi başarısız", 3);
                    }
                }
                else
                {
                    if(await GenericApiProvider<bool>.UpdateWithIdAsync("CarFeature", "UpdateCarFeatureAvailableChangeToFalse", item.Id) == true)
                    {
                        _otyfService.Success("Güncelleme işlemi başarılı", 3);
                    }
                    else
                    {
                        _otyfService.Success("Güncelleme işlemi başarısız", 3);
                    }
                }
            }
            return RedirectToAction("Index", "AdminCar");
        }

        [HttpGet]
        [Route("CreateFeatureByCarId")]
        public async Task<IActionResult> CreateFeatureByCarId()
        {
            
            return View(await GenericApiProvider<ResultCarFeaturesByCarIdDTO>.GetListAsync("Feature","FeatureList"));
        }
    }
}
