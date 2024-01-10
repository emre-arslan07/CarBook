using CarBook.Application.Features.Commands.AboutCommands;
using CarBook.Application.Features.Queries.AboutQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AboutController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
		[Route("AboutList")]
		public async Task<IActionResult> AboutList()
        {
            var values = await _mediator.Send(new GetAboutQuery());
            if (values != null)
            {
                return Ok(values);
            }else { return BadRequest("İşlem başarısız"); }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbout(int id)
        {
            var values = await _mediator.Send(new GetAboutByIdQuery(id));
            if (values != null)
            {
                return Ok(values);
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutCommand command)
        {
            var values = await _mediator.Send(command);
            if (values==true)
            {
                return Ok("İşlem başarılı");
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAbout(int id)
        {
            var values = await _mediator.Send(new RemoveAboutCommand(id));
            if (values == true)
            {
                return Ok("İşlem başarılı");
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand command)
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
