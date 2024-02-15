using CarBook.DTO.AppUserDTOs;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.Controllers
{
	public class LoginController : Controller
	{
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			return View();
		}

        [HttpPost]
        public async Task<IActionResult> Index(ResultLoginDTO resultLoginDTO)
        {
            return View();
        }
    }
}
