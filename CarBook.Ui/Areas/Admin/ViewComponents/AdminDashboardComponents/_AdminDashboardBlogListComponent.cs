using CarBook.DTO.BlogDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.Areas.Admin.ViewComponents.AdminDashboardComponents
{
    public class _AdminDashboardBlogListComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await GenericApiProvider<ResultLast3BlogWithAuthor>.GetListAsync("Blog", "Last3BlogsWithAuthor"));
        }
    }
}
