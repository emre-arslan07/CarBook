using CarBook.DTO.TestimonialDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.ViewComponents.TestimonialViewComponents
{
	public class _TestimonialComponent:ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View(await GenericApiProvider<TestimonialDTO>.GetListAsync("Testimonial", "TestimonialList"));
		}
	}
}
