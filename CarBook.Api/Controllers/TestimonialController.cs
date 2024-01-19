using CarBook.Application.Features.Commands.TestimonialCommands;
using CarBook.Application.Features.Queries.TestimonialQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestimonialController : ControllerBase
	{
		private readonly IMediator _mediator;

		public TestimonialController(IMediator mediator)
		{
			_mediator = mediator;
		}


		[HttpGet("TestimonialList")]
		public async Task<IActionResult> TestimonialList()
		{
			var values = await _mediator.Send(new GetTestimonialQuery());
			if (values != null)
			{
				return Ok(values);
			}
			else { return BadRequest("İşlem başarısız"); }
		}

		[HttpGet("GetTestimonial")]
		public async Task<IActionResult> GetTestimonial(int id)
		{
			var values = await _mediator.Send(new GetTestimonialByIdQuery(id));
			if (values != null)
			{
				return Ok(values);
			}
			else { return BadRequest("İşlem başarısız"); }
		}

        [HttpPost("CreateTestimonial")]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialCommand command)
		{
			var values = await _mediator.Send(command);
			if (values == true)
			{
				return Ok("İşlem başarılı");
			}
			else { return BadRequest("İşlem başarısız"); }
		}

		[HttpDelete("RemoveTestimonial")]
		public async Task<IActionResult> RemoveTestimonial(int id)
		{
			var values = await _mediator.Send(new RemoveTestimonialCommand(id));
			if (values == true)
			{
				return Ok("İşlem başarılı");
			}
			else { return BadRequest("İşlem başarısız"); }
		}

		[HttpPut("UpdateTestimonial")]
		public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialCommand command)
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
