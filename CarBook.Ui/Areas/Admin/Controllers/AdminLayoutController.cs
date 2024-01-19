using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.Areas.Admin.Controllers
{
    public class AdminLayoutController : Controller
    {
        [Area("Admin")]
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
