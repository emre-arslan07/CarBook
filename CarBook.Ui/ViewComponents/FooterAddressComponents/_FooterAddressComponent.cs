using CarBook.DTO.FooterAddressDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.ViewComponents.FooterAddressComponents
{
    public class _FooterAddressComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await GenericApiProvider<ResultFooterAddressDTO>.GetListAsync("FooterAddress", "FooterAddressList"));
        }
    }
}
