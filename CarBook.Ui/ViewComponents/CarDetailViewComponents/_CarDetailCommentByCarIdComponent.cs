using CarBook.DTO.ReviewDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.ViewComponents.CarDetailViewComponents
{
	public class _CarDetailCommentByCarIdComponent:ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync(int id)
		{

			return View(await GenericApiProvider<ResultGetReviewsByCarIdDTO>.GetListAsyncById("Review", "GetReviewsByCarId",id));
		}
	}
}
