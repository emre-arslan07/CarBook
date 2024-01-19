using CarBook.Application.Features.Commands.BannerCommands;
using CarBook.Application.Features.Commands.BrandCommands;
using CarBook.Application.Features.Queries.BannerQueries;
using CarBook.Application.Features.Queries.BrandQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandController(IMediator mediator)
        {
            _mediator = mediator;
        }

		[HttpGet("BrandList")]
		public async Task<IActionResult> BrandList()
        {
            var values = await _mediator.Send(new GetBrandQuery());
            if (values != null)
            {
                return Ok(values);
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpGet("GetBrand")]
        public async Task<IActionResult> GetBrand(int id)
        {
            var values = await _mediator.Send(new GetBrandByIdQuery(id));
            if (values != null)
            {
                return Ok(values);
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpPost("CreateBrand")]

        public async Task<IActionResult> CreateBrand(CreateBrandCommand command)
        {
            var values = await _mediator.Send(command);
            if (values == true)
            {
                return Ok("İşlem başarılı");
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpDelete("RemoveBrand")]
        public async Task<IActionResult> RemoveBrand(int id)
        {
            var values = await _mediator.Send(new RemoveBrandCommand(id));
            if (values == true)
            {
                return Ok("İşlem başarılı");
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpPut("UpdateBrand")]
        public async Task<IActionResult> UpdateBrand(UpdateBrandCommand command)
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
