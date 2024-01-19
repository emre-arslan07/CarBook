using CarBook.Application.Features.Commands.ServiceCommands;
using CarBook.Application.Features.Queries.ServiceQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

		[HttpGet("ServiceList")]
		public async Task<IActionResult> ServiceList()
        {
            var values = await _mediator.Send(new GetServiceQuery());
            if (values != null)
            {
                return Ok(values);
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpGet("GetService")]
        public async Task<IActionResult> GetService(int id)
        {
            var values = await _mediator.Send(new GetServiceByIdQuery(id));
            if (values != null)
            {
                return Ok(values);
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpPost("CreateService")]
        public async Task<IActionResult> CreateService(CreateServiceCommand command)
        {
            var values = await _mediator.Send(command);
            if (values == true)
            {
                return Ok("İşlem başarılı");
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpDelete("RemoveService")]
        public async Task<IActionResult> RemoveService(int id)
        {
            var values = await _mediator.Send(new RemoveServiceCommand(id));
            if (values == true)
            {
                return Ok("İşlem başarılı");
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpPut("UpdateService")]
        public async Task<IActionResult> UpdateService(UpdateServiceCommand command)
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
