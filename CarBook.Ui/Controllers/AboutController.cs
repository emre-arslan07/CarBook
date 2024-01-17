using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.Controllers
{
    public class AboutController : Controller
    {
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			ViewBag.v1 = "Hakkımızda";
			ViewBag.v2 = "Hakkımızda";
			return View();
		}
	}
}
