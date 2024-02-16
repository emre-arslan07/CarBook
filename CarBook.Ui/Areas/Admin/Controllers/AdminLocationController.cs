using AspNetCoreHero.ToastNotification.Abstractions;
using CarBook.DTO.LocationDTOs;
using CarBook.Ui.ApiProvider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;

namespace CarBook.Ui.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    [Area("Admin")]
    [Route("Admin/AdminLocation")]
    public class AdminLocationController : Controller
    {
        private readonly INotyfService _otyfService;

        public AdminLocationController(INotyfService otyfService)
        {
            _otyfService = otyfService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var token=User.Claims.FirstOrDefault(x=>x.Type== "carbooktoken")?.Value;
            if (token != null)
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var responseMessage = await client.GetAsync("https://localhost:7060/api/Location/LocationList");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultLocationDTO>>(jsonData);
                    return View(values);
                }
            }
            return View();
            //return View(await GenericApiProvider<ResultLocationDTO>.GetListAsync("Location", "LocationList"));
        }

        [HttpGet]
        [Route("CreateLocation")]
        public async Task<IActionResult> CreateLocation()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateLocation")]
        public async Task<IActionResult> CreateLocation(ResultCreateLocationDTO resultCreateLocationDTO)
        {
            if (await GenericApiProvider<ResultCreateLocationDTO>.AddTentityAsync("Location", "CreateLocation", resultCreateLocationDTO) == true)
            {
                _otyfService.Success("Ekleme işlemi başarılı", 3);
                return RedirectToAction("Index", "AdminLocation", new { area = "Admin" });
            }
            else
            {
                _otyfService.Error("Ekleme işlemi başarısız", 3);
                return RedirectToAction("CreateLocation", "AdminLocation", new { area = "Admin" });
            }
        }

        [Route("RemoveLocation/{id}")]
        public async Task<IActionResult> RemoveLocation(int id)
        {
            if (await GenericApiProvider<bool>.DeleteTentityAsync("Location", "RemoveLocation", id) == true)
            {
                return RedirectToAction("Index", "AdminLocation", new { area = "Admin" });
            }
            else
            {
                return RedirectToAction("Index", "AdminLocation", new { area = "Admin" });
            }
        }


        [HttpGet]
        [Route("UpdateLocation/{id}")]
        public async Task<IActionResult> UpdateLocation(int id)
        {
            return View(await GenericApiProvider<ResultUpdateLocationDTO>.GetAsyncById("Location", "GetLocation", id));
        }

        [HttpPost]
        [Route("UpdateLocation/{id}")]
        public async Task<IActionResult> UpdateLocation(ResultUpdateLocationDTO resultUpdateLocationDTO)
        {
            if (await GenericApiProvider<ResultUpdateLocationDTO>.UpdateTentityAsync("Location", "UpdateLocation", resultUpdateLocationDTO) == true)
            {
                _otyfService.Success("Güncelleme işlemi başarılı", 3);
                return RedirectToAction("Index", "AdminLocation", new { area = "Admin" });
            }
            else
            {
                _otyfService.Error("Güncelleme işlemi başarısız", 3);
                return RedirectToAction("UpdateLocation", "AdminLocation", new { area = "Admin" });
            }
        }
    }
}
