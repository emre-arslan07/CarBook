using CarBook.DTO.CarDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.Controllers
{
    public class CarController : Controller
    {
        public async  Task<IActionResult> Index()
        {
            return View(await GenericApiProvider<ResultCarDTO>.GetListAsync("Car", "GetCarWithBrand")); 
        }
    }
}
