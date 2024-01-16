using CarBook.DTO.ServiceDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.ViewComponents.ServiceViewComponents
{
    public class _ServiceComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await GenericApiProvider<ResultServiceDTO>.GetListAsync("Service","ServiceList"));
        }
    }
}
