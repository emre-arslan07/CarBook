using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.Controllers
{
    public class DefaultController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
