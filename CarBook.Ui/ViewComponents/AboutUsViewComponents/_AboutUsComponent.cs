using CarBook.DTO.AboutDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.Ui.ViewComponents.AboutUsViewComponents
{
	public class _AboutUsComponent:ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{			
			return View(await GenericApiProvider<ResultAboutDTO>.GetListAsync("About","AboutList"));
		}
	}
}
