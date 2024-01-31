using CarBook.DTO.RentACarDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.Controllers
{
	public class RentACarListController : Controller
	{
		[HttpGet]
		public async Task<IActionResult> Index(int id)
		{
			var Id = TempData["Id"];
			 id = int.Parse(Id.ToString());
			ViewBag.Id = Id;
		

			
			return View(await GenericApiProvider<ResultFilterRentACarDTO>.GetCarListByFilter("RentACar", "GetRentACarListByLocation",id,true));
		}
	}
}
