using CarBook.Application.Features.Queries.AboutQueries;
using CarBook.Application.Features.Queries.CarDescriptionQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarDescriptionController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CarDescriptionController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("GetCarDescriptionByCarId")]
		public async Task<IActionResult> GetCarDescriptionByCarId(int id)
		{
			var values = await _mediator.Send(new GetCarDescriptionByCarIdQuery(id));
			if (values != null)
			{
				return Ok(values);
			}
			else { return BadRequest("İşlem başarısız"); }
		}
	}
}
