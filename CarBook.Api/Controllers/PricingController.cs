using CarBook.Application.Features.Commands.PricingCommands;
using CarBook.Application.Features.Queries.PricingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PricingController(IMediator mediator)
        {
            _mediator = mediator;
        }


		[HttpGet("PricingList")]
		public async Task<IActionResult> PricingList()
        {
            var values = await _mediator.Send(new GetPricingQuery());
            if (values != null)
            {
                return Ok(values);
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpGet("GetPricing")]
        public async Task<IActionResult> GetPricing(int id)
        {
            var values = await _mediator.Send(new GetPricingByIdQuery(id));
            if (values != null)
            {
                return Ok(values);
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpPost("CreatePricing")]
        public async Task<IActionResult> CreatePricing(CreatePricingCommand command)
        {
            var values = await _mediator.Send(command);
            if (values == true)
            {
                return Ok("İşlem başarılı");
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpDelete("RemovePricing")]
        public async Task<IActionResult> RemovePricing(int id)
        {
            var values = await _mediator.Send(new RemovePricingCommand(id));
            if (values == true)
            {
                return Ok("İşlem başarılı");
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpPut("UpdatePricing")]
        public async Task<IActionResult> UpdatePricing(UpdatePricingCommand command)
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
