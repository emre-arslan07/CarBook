using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.ViewComponents.CarDetailViewComponents
{
	public class _CarDetailTopPaneComponent:ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View();
		}
	}
}
