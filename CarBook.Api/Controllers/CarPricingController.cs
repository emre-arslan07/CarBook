using CarBook.Application.Features.Queries.BannerQueries;
using CarBook.Application.Features.Queries.CarPricingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPricingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarPricingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCarPricingWithCarList")]

        public async Task<IActionResult> GetCarPricingWithCarList()
        {
            var values = await _mediator.Send(new GetCarPricingWithCarQuery());
            if (values != null)
            {
                return Ok(values);
            }
            else { return BadRequest("İşlem başarısız"); }
        }
    }
}
