using CarBook.DTO.FooterAddressDTOs;
using CarBook.DTO.SocialMediaDTO;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.ViewComponents.UILayoutViewComponents
{
    public class _FooterUILayoutComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {          
            return View(await GenericApiProvider<ResultFooterAddressDTO>.GetListAsync("FooterAddress", "FooterAddressList"));
        }
    }
}
