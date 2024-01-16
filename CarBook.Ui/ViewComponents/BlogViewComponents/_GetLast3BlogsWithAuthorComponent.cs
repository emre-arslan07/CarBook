using CarBook.DTO.BlogDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.ViewComponents.BlogViewComponents
{
    public class _GetLast3BlogsWithAuthorComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await GenericApiProvider<ResultLast3BlogWithAuthor>.GetListAsync("Blog", "Last3BlogsWithAuthor"));
        }
    }
}
