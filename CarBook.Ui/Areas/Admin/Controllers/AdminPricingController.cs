using AspNetCoreHero.ToastNotification.Abstractions;
using CarBook.DTO.PricingDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminPricing")]
    public class AdminPricingController : Controller
    {
        private readonly INotyfService _otyfService;

        public AdminPricingController(INotyfService otyfService)
        {
            _otyfService = otyfService;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            return View(await GenericApiProvider<ResultPricingDTO>.GetListAsync("Pricing", "PricingList"));
        }

        [HttpGet]
        [Route("CreatePricing")]
        public async Task<IActionResult> CreatePricing()
        {
            return View();
        }
        [HttpPost]
        [Route("CreatePricing")]
        public async Task<IActionResult> CreatePricing(ResultCreatePricingDTO resultCreatePricingDTO)
        {
            if (await GenericApiProvider<ResultCreatePricingDTO>.AddTentityAsync("Pricing", "CreatePricing", resultCreatePricingDTO) == true)
            {
                _otyfService.Success("Ekleme işlemi başarılı", 3);
                return RedirectToAction("Index", "AdminPricing", new { area = "Admin" });
            }
            else
            {
                _otyfService.Error("Ekleme işlemi başarısız", 3);
                return RedirectToAction("CreatePricing", "AdminPricing", new { area = "Admin" });
            }
        }

        [Route("RemovePricing/{id}")]
        public async Task<IActionResult> RemovePricing(int id)
        {
            if (await GenericApiProvider<bool>.DeleteTentityAsync("Pricing", "RemovePricing", id) == true)
            {
                return RedirectToAction("Index", "AdminPricing", new { area = "Admin" });
            }
            else
            {
                return RedirectToAction("Index", "AdminPricing", new { area = "Admin" });
            }
        }


        [HttpGet]
        [Route("UpdatePricing/{id}")]
        public async Task<IActionResult> UpdatePricing(int id)
        {
            return View(await GenericApiProvider<ResultUpdatePricingDTO>.GetAsyncById("Pricing", "GetPricing", id));
        }

        [HttpPost]
        [Route("UpdatePricing/{id}")]
        public async Task<IActionResult> UpdatePricing(ResultUpdatePricingDTO resultUpdatePricingDTO)
        {
            if (await GenericApiProvider<ResultUpdatePricingDTO>.UpdateTentityAsync("Pricing", "UpdatePricing", resultUpdatePricingDTO) == true)
            {
                _otyfService.Success("Güncelleme işlemi başarılı", 3);
                return RedirectToAction("Index", "AdminPricing", new { area = "Admin" });
            }
            else
            {
                _otyfService.Error("Güncelleme işlemi başarısız", 3);
                return RedirectToAction("UpdatePricing", "AdminPricing", new { area = "Admin" });
            }
        }
    }
}
