using CarBook.DTO.AppUserDTOs;
using CarBook.DTO.CommentDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Ui.Controllers
{
    [AllowAnonymous]

    public class RegisterController : Controller
	{
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(ResultRegisterDTO resultRegisterDTO)
		{
            if (resultRegisterDTO != null)
            {
                if (await GenericApiProvider<ResultRegisterDTO>.AddTentityAsync("SignUp", "Register", resultRegisterDTO) == true)
                {
                    return RedirectToAction("Index", "Default");
                }
                else
                {
                    return View(resultRegisterDTO);
                }
            }
            return View();
        }
	}
}
