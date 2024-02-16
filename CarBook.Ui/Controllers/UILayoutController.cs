using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.Controllers
{
    [AllowAnonymous]

    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
