using AspNetCoreHero.ToastNotification.Abstractions;
using CarBook.DTO.FooterAddressDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminFooterAddress")]
    public class AdminFooterAddressController : Controller
    {
        private readonly INotyfService _otyfService;

        public AdminFooterAddressController(INotyfService otyfService)
        {
            _otyfService = otyfService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            return View(await GenericApiProvider<ResultFooterAddressDTO>.GetListAsync("FooterAddress", "FooterAddressList"));
        }

        [HttpGet]
        [Route("CreateFooterAddress")]
        public async Task<IActionResult> CreateFooterAddress()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateFooterAddress")]
        public async Task<IActionResult> CreateFooterAddress(ResultCreateFooterAddressDTO resultCreateFooterAddressDTO)
        {
            if (await GenericApiProvider<ResultCreateFooterAddressDTO>.AddTentityAsync("FooterAddress", "CreateFooterAddress", resultCreateFooterAddressDTO) == true)
            {
                _otyfService.Success("Ekleme işlemi başarılı", 3);
                return RedirectToAction("Index", "AdminFooterAddress", new { area = "Admin" });
            }
            else
            {
                _otyfService.Error("Ekleme işlemi başarısız", 3);
                return RedirectToAction("CreateFooterAddress", "AdminFooterAddress", new { area = "Admin" });
            }
        }

        [Route("RemoveFooterAddress/{id}")]
        public async Task<IActionResult> RemoveFooterAddress(int id)
        {
            if (await GenericApiProvider<bool>.DeleteTentityAsync("FooterAddress", "RemoveFooterAddress", id) == true)
            {
                return RedirectToAction("Index", "AdminFooterAddress", new { area = "Admin" });
            }
            else
            {
                return RedirectToAction("Index", "AdminFooterAddress", new { area = "Admin" });
            }
        }


        [HttpGet]
        [Route("UpdateFooterAddress/{id}")]
        public async Task<IActionResult> UpdateFooterAddress(int id)
        {
            return View(await GenericApiProvider<ResultUpdateFooterAddressDTO>.GetAsyncById("FooterAddress", "GetFooterAddress", id));
        }

        [HttpPost]
        [Route("UpdateFooterAddress/{id}")]
        public async Task<IActionResult> UpdateFooterAddress(ResultUpdateFooterAddressDTO resultUpdateFooterAddressDTO)
        {
            if (await GenericApiProvider<ResultUpdateFooterAddressDTO>.UpdateTentityAsync("FooterAddress", "UpdateFooterAddress", resultUpdateFooterAddressDTO) == true)
            {
                _otyfService.Success("Güncelleme işlemi başarılı", 3);
                return RedirectToAction("Index", "AdminFooterAddress", new { area = "Admin" });
            }
            else
            {
                _otyfService.Error("Güncelleme işlemi başarısız", 3);
                return RedirectToAction("UpdateFooterAddress", "AdminFooterAddress", new { area = "Admin" });
            }
        }
    }
}
