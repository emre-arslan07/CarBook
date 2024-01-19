using CarBook.Application.Features.Commands.AboutCommands;
using CarBook.Application.Features.Commands.BannerCommands;
using CarBook.Application.Features.Queries.AboutQueries;
using CarBook.Application.Features.Queries.BannerQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BannerController(IMediator mediator)
        {
            _mediator = mediator;
        }

		[HttpGet("BannerList")]
		public async Task<IActionResult> BannerList()
        {
            var values = await _mediator.Send(new GetBannerQuery());
            if (values != null)
            {
                return Ok(values);
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpGet("GetBanner")]
        public async Task<IActionResult> GetBanner(int id)
        {
            var values = await _mediator.Send(new GetBannerByIdQuery(id));
            if (values != null)
            {
                return Ok(values);
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpPost("CreateBanner")]
        public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
        {
            var values = await _mediator.Send(command);
            if (values == true)
            {
                return Ok("İşlem başarılı");
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpDelete("RemoveBanner")]
        public async Task<IActionResult> RemoveBanner(int id)
        {
            var values = await _mediator.Send(new RemoveBannerCommand(id));
            if (values == true)
            {
                return Ok("İşlem başarılı");
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpPut("UpdateBanner")]
        public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
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
