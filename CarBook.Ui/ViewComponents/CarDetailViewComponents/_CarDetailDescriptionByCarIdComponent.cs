using CarBook.DTO.CarDescriptionDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.ViewComponents.CarDetailViewComponents
{
	public class _CarDetailDescriptionByCarIdComponent:ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			ViewBag.Id=id;
			return View(await GenericApiProvider<ResultCarDescriptionDTO>.GetAsyncById("CarDescription", "GetCarDescriptionByCarId",id));
		}
	}
}
