using AspNetCoreHero.ToastNotification.Abstractions;
using CarBook.DTO.ServiceDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminService")]
    public class AdminServiceController : Controller
    {
        private readonly INotyfService _otyfService;

        public AdminServiceController(INotyfService otyfService)
        {
            _otyfService = otyfService;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            return View(await GenericApiProvider<ResultServiceDTO>.GetListAsync("Service", "ServiceList"));
        }

        [HttpGet]
        [Route("CreateService")]
        public async Task<IActionResult> CreateService()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateService")]
        public async Task<IActionResult> CreateService(ResultCreateServiceDTO resultCreateServiceDTO)
        {
            if (await GenericApiProvider<ResultCreateServiceDTO>.AddTentityAsync("Service", "CreateService", resultCreateServiceDTO) == true)
            {
                _otyfService.Success("Ekleme işlemi başarılı", 3);
                return RedirectToAction("Index", "AdminService", new { area = "Admin" });
            }
            else
            {
                _otyfService.Error("Ekleme işlemi başarısız", 3);
                return RedirectToAction("CreateService", "AdminService", new { area = "Admin" });
            }
        }

        [Route("RemoveService/{id}")]
        public async Task<IActionResult> RemoveService(int id)
        {
            if (await GenericApiProvider<bool>.DeleteTentityAsync("Service", "RemoveService", id) == true)
            {
                return RedirectToAction("Index", "AdminService", new { area = "Admin" });
            }
            else
            {
                return RedirectToAction("Index", "AdminService", new { area = "Admin" });
            }
        }


        [HttpGet]
        [Route("UpdateService/{id}")]
        public async Task<IActionResult> UpdateService(int id)
        {
            return View(await GenericApiProvider<ResultUpdateServiceDTO>.GetAsyncById("Service", "GetService", id));
        }

        [HttpPost]
        [Route("UpdateService/{id}")]
        public async Task<IActionResult> UpdateService(ResultUpdateServiceDTO resultUpdateServiceDTO)
        {
            if (await GenericApiProvider<ResultUpdateServiceDTO>.UpdateTentityAsync("Service", "UpdateService", resultUpdateServiceDTO) == true)
            {
                _otyfService.Success("Güncelleme işlemi başarılı", 3);
                return RedirectToAction("Index", "AdminService", new { area = "Admin" });
            }
            else
            {
                _otyfService.Error("Güncelleme işlemi başarısız", 3);
                return RedirectToAction("UpdateService", "AdminService", new { area = "Admin" });
            }
        }
    }
}
