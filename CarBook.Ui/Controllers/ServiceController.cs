using CarBook.DTO.ServiceDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.Controllers
{
	public class ServiceController : Controller
	{
		public async Task<IActionResult> Index()
		{
			return View(await GenericApiProvider<ResultServiceDTO>.GetListAsync("Service","ServiceList"));
		}
	}
}
