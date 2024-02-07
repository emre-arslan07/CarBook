using CarBook.DTO.CarFeatureDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.ViewComponents.CarDetailViewComponents
{
	public class _CarDetailCarFeatureByCarIdComponent:ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			ViewBag.Id = id;
			return View(await GenericApiProvider<ResultCarFeaturesByCarIdDTO>.GetListAsyncById("CarFeature", "GetCarFeatureByCarId",id));
		}
	}
}
