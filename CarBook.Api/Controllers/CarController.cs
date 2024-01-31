using CarBook.Application.Features.Commands.CarCommands;
using CarBook.Application.Features.Queries.CarQueries;
using CarBook.Application.Features.Queries.StatisticQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarController(IMediator mediator)
        {
            _mediator = mediator;
        }

		[HttpGet("CarList")]

		public async Task<IActionResult> CarList()
        {
            var values = await _mediator.Send(new GetCarQuery());
            if (values != null)
            {
                return Ok(values);
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        

        [HttpGet("GetCarWithBrand")]
        public async Task<IActionResult> CarListWithBrand()
        {
            var values = await _mediator.Send(new GetCarWithBrandQuery());
            if (values != null)
            {
                return Ok(values);
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpGet("Last5CarsListWithBrand")]
        public async Task<IActionResult> Last5CarsListWithBrand()
        {
            var values = await _mediator.Send(new GetLast5CarsWithBrandQuery());
            if (values != null)
            {
                return Ok(values);
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpGet("GetCar")]
        public async Task<IActionResult> GetCar(int id)
        {
            var values = await _mediator.Send(new GetCarByIdQuery(id));
            if (values != null)
            {
                return Ok(values);
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpGet("GetCarWithBrandById")]
        public async Task<IActionResult> GetCarWithBrandById(int id)
        {
            var values = await _mediator.Send(new GetCarWithBrandByIdQuery(id));
            if (values != null)
            {
                return Ok(values);
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpPost("CreateCar")]

        public async Task<IActionResult> CreateCar(CreateCarCommand command)
        {
            var values = await _mediator.Send(command);
            if (values == true)
            {
                return Ok("İşlem başarılı");
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpDelete("RemoveCar")]
        public async Task<IActionResult> RemoveCar(int id)
        {
            var values = await _mediator.Send(new RemoveCarCommand(id));
            if (values == true)
            {
                return Ok("İşlem başarılı");
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpPut("UpdateCar")]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
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
