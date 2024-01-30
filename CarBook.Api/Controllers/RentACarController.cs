using CarBook.Application.Features.Queries.AuthorQueries;
using CarBook.Application.Features.Queries.RentACarQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RentACarController : ControllerBase
	{
		private readonly IMediator _mediator;

		public RentACarController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost("GetRentACarListByLocation")]
		public async Task<IActionResult> GetRentACarListByLocation(GetRentACarQuery rentACarQuery)
		{
			var values = await _mediator.Send(rentACarQuery);
			if (values != null)
			{
				return Ok(values);
			}
			else { return BadRequest("İşlem başarısız"); }
		}
	}
}
