using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.Controllers
{
    public class AboutController : Controller
    {
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
	}
}
