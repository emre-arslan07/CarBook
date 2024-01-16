using CarBook.DTO.BannerDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.ViewComponents.DefaultViewComponents
{
    public class _DefaultCoverUILayoutComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await GenericApiProvider<ResultBannerDTO>.GetListAsync("Banner","BannerList"));
        }
    }
}
