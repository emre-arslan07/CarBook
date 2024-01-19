using CarBook.DTO.CarDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCar")]
    public class AdminCarController : Controller
    {
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            return View(await GenericApiProvider<ResultCarWithBrandDTO>.GetListAsync("Car", "GetCarWithBrand"));
        }
    }
}
