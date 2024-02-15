using CarBook.Application.Features.Queries.AppUserQueries;
using CarBook.Application.Features.Queries.AuthorQueries;
using CarBook.Application.Tools;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SignInController : ControllerBase
	{
		private readonly IMediator _mediator;

		public SignInController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost("Login")]
		public async Task<IActionResult> Login(GetCheckAppUserQuery getCheckAppUserQuery)
		{
			var values = await _mediator.Send(getCheckAppUserQuery);
			if (values.IsExist)
			{
				return Created("",JwtTokenGenerator.GenerateToken(values));
			}
			else { return BadRequest("Kullanıcı adı veya şifre hatalı"); }
		}
	}
}
