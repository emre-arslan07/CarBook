using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Notyf;
using CarBook.DTO.ContactDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminContact")]
    public class AdminContactController : Controller
    {
        private readonly INotyfService _notyfService;

        public AdminContactController(INotyfService notyfService)
        {
            _notyfService = notyfService;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            return View(await GenericApiProvider<ResultContactDTO>.GetListAsync("Contact", "ContactList"));
        }

        [Route("RemoveContact/{id}")]
        public async Task<IActionResult> RemoveContact(int id)
        {
            if (await GenericApiProvider<bool>.DeleteTentityAsync("Contact", "RemoveContact", id) == true)
            {
                return RedirectToAction("Index", "AdminContact", new { area = "Admin" });
            }
            else
            {
                return RedirectToAction("Index", "AdminContact", new { area = "Admin" });
            }
        }

    }
}
