using CarBook.Application.Features.Commands.SocialMediaCommands;
using CarBook.Application.Features.Queries.SocialMediaQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SocialMediaController(IMediator mediator)
        {
            _mediator = mediator;
        }


		[HttpGet("SocialMediaList")]
		public async Task<IActionResult> SocialMediaList()
        {
            var values = await _mediator.Send(new GetSocialMediaQuery());
            if (values != null)
            {
                return Ok(values);
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpGet("GetSocialMedia")]
        public async Task<IActionResult> GetSocialMedia(int id)
        {
            var values = await _mediator.Send(new GetSocialMediaByIdQuery(id));
            if (values != null)
            {
                return Ok(values);
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpPost("CreateSocialMedia")]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaCommand command)
        {
            var values = await _mediator.Send(command);
            if (values == true)
            {
                return Ok("İşlem başarılı");
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpDelete("RemoveSocialMedia")]
        public async Task<IActionResult> RemoveSocialMedia(int id)
        {
            var values = await _mediator.Send(new RemoveSocialMediaCommand(id));
            if (values == true)
            {
                return Ok("İşlem başarılı");
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpPut("UpdateSocialMedia")]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaCommand command)
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
