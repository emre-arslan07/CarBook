using CarBook.Application.Features.Commands.AppUserCommands;
using CarBook.Application.Features.Commands.BlogCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SignUpController : ControllerBase
	{
		private readonly IMediator _mediator;

		public SignUpController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost("Register")]
		public async Task<IActionResult> Register(CreateAppUserCommand command)
		{
			var values = await _mediator.Send(command);
			if (values == true)
			{
				return Ok("İşlem başarılı");
			}
			else { return BadRequest("İşlem başarısız"); }
		}
	}
}
