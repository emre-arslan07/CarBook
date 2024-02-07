using CarBook.Application.Features.Commands.CarCommands;
using CarBook.Application.Features.Commands.CarFeatureCommands;
using CarBook.Application.Features.Queries.AuthorQueries;
using CarBook.Application.Features.Queries.CarFeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeatureController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarFeatureController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCarFeatureByCarId")]
        public async Task<IActionResult> GetCarFeatureByCarId(int id)
        {
            var values = await _mediator.Send(new GetCarFeatureByCarIdQuery(id));
            if (values != null)
            {
                return Ok(values);
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpGet("UpdateCarFeatureAvailableChangeToFalse")]
        public async Task<IActionResult> UpdateCarFeatureAvailableChangeToFalse(int id)
        {
            var values = await _mediator.Send(new UpdateCarFeatureAvailableChangeToFalseCommand(id));
            if (values == true)
            {
                return Ok(values);
            }
            else { return BadRequest("İşlem başarısız"); }
        }
        
        [HttpGet("UpdateCarFeatureAvailableChangeToTrue")]  
        public async Task<IActionResult> UpdateCarFeatureAvailableChangeToTrue(int id)
        {
            var values = await _mediator.Send(new UpdateCarFeatureAvailableChangeToTrueCommand(id));
            if (values == true)
            {
                return Ok(values);
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpPost("CreateCarFeatureByCar")]
        public async Task<IActionResult> CreateCarFeatureByCar(CreateCarFeatureByCarCommand command)
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
