using CarBook.DTO.ServiceDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.Controllers
{
	public class ServiceController : Controller
	{
		public async Task<IActionResult> Index()

		{
            ViewBag.v1="Hizmetler";
            ViewBag.v2="Hizmetlerimiz";
			return View(await GenericApiProvider<ResultServiceDTO>.GetListAsync("Service","ServiceList"));
		}
	}
}
