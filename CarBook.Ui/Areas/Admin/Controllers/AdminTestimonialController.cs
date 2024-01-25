using AspNetCoreHero.ToastNotification.Abstractions;
using CarBook.DTO.TestimonialDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminTestimonial")]
    public class AdminTestimonialController : Controller
    {
        private readonly INotyfService _otyfService;

        public AdminTestimonialController(INotyfService otyfService)
        {
            _otyfService = otyfService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            return View(await GenericApiProvider<ResultTestimonialDTO>.GetListAsync("Testimonial", "TestimonialList"));
        }

        [HttpGet]
        [Route("CreateTestimonial")]
        public async Task<IActionResult> CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateTestimonial")]
        public async Task<IActionResult> CreateTestimonial(ResultCreateTestimonialDTO resultCreateTestimonialDTO)
        {
            if (await GenericApiProvider<ResultCreateTestimonialDTO>.AddTentityAsync("Testimonial", "CreateTestimonial", resultCreateTestimonialDTO) == true)
            {
                _otyfService.Success("Ekleme işlemi başarılı", 3);
                return RedirectToAction("Index", "AdminTestimonial", new { area = "Admin" });
            }
            else
            {
                _otyfService.Error("Ekleme işlemi başarısız", 3);
                return RedirectToAction("CreateTestimonial", "AdminTestimonial", new { area = "Admin" });
            }
        }

        [Route("RemoveTestimonial/{id}")]
        public async Task<IActionResult> RemoveTestimonial(int id)
        {
            if (await GenericApiProvider<bool>.DeleteTentityAsync("Testimonial", "RemoveTestimonial", id) == true)
            {
                return RedirectToAction("Index", "AdminTestimonial", new { area = "Admin" });
            }
            else
            {
                return RedirectToAction("Index", "AdminTestimonial", new { area = "Admin" });
            }
        }


        [HttpGet]
        [Route("UpdateTestimonial/{id}")]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            return View(await GenericApiProvider<ResultUpdateTestimonialDTO>.GetAsyncById("Testimonial", "GetTestimonial", id));
        }

        [HttpPost]
        [Route("UpdateTestimonial/{id}")]
        public async Task<IActionResult> UpdateTestimonial(ResultUpdateTestimonialDTO resultUpdateTestimonialDTO)
        {
            if (await GenericApiProvider<ResultUpdateTestimonialDTO>.UpdateTentityAsync("Testimonial", "UpdateTestimonial", resultUpdateTestimonialDTO) == true)
            {
                _otyfService.Success("Güncelleme işlemi başarılı", 3);
                return RedirectToAction("Index", "AdminTestimonial", new { area = "Admin" });
            }
            else
            {
                _otyfService.Error("Güncelleme işlemi başarısız", 3);
                return RedirectToAction("UpdateTestimonial", "AdminTestimonial", new { area = "Admin" });
            }
        }
    }
}
