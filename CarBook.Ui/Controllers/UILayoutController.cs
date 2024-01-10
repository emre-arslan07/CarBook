using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
