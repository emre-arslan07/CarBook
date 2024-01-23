using AspNetCoreHero.ToastNotification.Abstractions;
using CarBook.DTO.CategoryDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCategory")]
    public class AdminCategoryController : Controller
    {
        private readonly INotyfService _otyfService;

        public AdminCategoryController(INotyfService otyfService)
        {
            _otyfService = otyfService;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            return View(await GenericApiProvider<ResultCategoryDTO>.GetListAsync("Category", "CategoryList"));
        }

        [HttpGet]
        [Route("CreateCategory")]
        public async Task<IActionResult> CreateCategory()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IActionResult> CreateCategory(ResultCreateCategoryDTO resultCreateCategoryDTO)
        {
            if (await GenericApiProvider<ResultCreateCategoryDTO>.AddTentityAsync("Category", "CreateCategory", resultCreateCategoryDTO) == true)
            {
                _otyfService.Success("Ekleme işlemi başarılı", 3);
                return RedirectToAction("Index", "AdminCategory", new { area = "Admin" });
            }
            else
            {
                _otyfService.Error("Ekleme işlemi başarısız", 3);
                return RedirectToAction("CreateCategory", "AdminCategory", new { area = "Admin" });
            }
        }

        [Route("RemoveCategory/{id}")]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            if (await GenericApiProvider<bool>.DeleteTentityAsync("Category", "RemoveCategory", id) == true)
            {
                return RedirectToAction("Index", "AdminCategory", new { area = "Admin" });
            }
            else
            {
                return RedirectToAction("Index", "AdminCategory", new { area = "Admin" });
            }
        }


        [HttpGet]
        [Route("UpdateCategory/{id}")]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            return View(await GenericApiProvider<ResultUpdateCategoryDTO>.GetAsyncById("Category", "GetCategory", id));
        }

        [HttpPost]
        [Route("UpdateCategory/{id}")]
        public async Task<IActionResult> UpdateCategory(ResultUpdateCategoryDTO resultUpdateCategoryDTO)
        {
            if (await GenericApiProvider<ResultUpdateCategoryDTO>.UpdateTentityAsync("Category", "UpdateCategory", resultUpdateCategoryDTO) == true)
            {
                _otyfService.Success("Güncelleme işlemi başarılı", 3);
                return RedirectToAction("Index", "AdminCategory", new { area = "Admin" });
            }
            else
            {
                _otyfService.Error("Güncelleme işlemi başarısız", 3);
                return RedirectToAction("UpdateCategory", "AdminCategory", new { area = "Admin" });
            }
        }
    }
}
