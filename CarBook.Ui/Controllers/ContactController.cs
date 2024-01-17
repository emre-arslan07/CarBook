using CarBook.DTO.ContactDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "İletişim";
            ViewBag.v2 = "Bize Ulaşın";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDTO createContactDTO)
        {
            if (createContactDTO != null)
            {
                createContactDTO.SendDate = DateTime.UtcNow;
                if (await GenericApiProvider<CreateContactDTO>.AddTentityAsync("Contact", "CreateContact",createContactDTO)==true)
                {
                    return RedirectToAction("Index","Default");
                }
                else
                {
                    return View(createContactDTO);
                }
            }
            return View();
        }

    }
}
