using CarBook.DTO.CarDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.ViewComponents.CarDetailViewComponents
{
	public class _CarDetailMainCarFeatureComponent:ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			ViewBag.Id = id;
			return View(await GenericApiProvider<ResultCarWithBrandDTO>.GetAsyncById("Car", "GetCarWithBrandById", id));
		}
	}
}
