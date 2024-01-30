using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.Controllers
{
	public class RentACarListController : Controller
	{
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			return View();
		}
	}
}
