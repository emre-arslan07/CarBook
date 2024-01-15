using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.ViewComponents.AboutUsViewComponents
{
	public class _BecomeDriverComponent:ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View();
		}
	}
}
