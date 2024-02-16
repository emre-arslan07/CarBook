using CarBook.DTO.AppUserDTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Text.Json;
using System.Text;
using CarBook.DTO.TokenDTO;

namespace CarBook.Ui.Controllers
{
	public class LoginController : Controller
    {
        [HttpGet]
		public async Task<IActionResult> Index()
		{
			return View();
		}

        [HttpPost]
        public async Task<IActionResult> Index(ResultLoginDTO resultLoginDTO)
        {
            var client = new HttpClient();
            var content = new StringContent(JsonSerializer.Serialize(resultLoginDTO), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:44351/api/SignIn/Login", content);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var tokenModel = JsonSerializer.Deserialize<ResultJwtReponseDTO>(jsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                if (tokenModel != null)
                {
                    JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(tokenModel.Token);
                    var claims = token.Claims.ToList();

                    if (tokenModel.Token != null)
                    {
                        claims.Add(new Claim("carbooktoken", tokenModel.Token));
                        var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                        var authProps = new AuthenticationProperties
                        {
                            ExpiresUtc = tokenModel.ExpireDate,
                            IsPersistent = true
                        };

                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
                        return RedirectToAction("Index", "Default");
                    }
                }
            }

            return View();
        }
    }
    }

