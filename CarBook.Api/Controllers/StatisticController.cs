using CarBook.Application.Features.Queries.StatisticQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatisticController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCarCount")]

        public async Task<IActionResult> GetCarCount()
        {
            var values = await _mediator.Send(new GetCarCountQuery());
            if (values != null)
            {
                return Ok(values);
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpGet("GetAuthorCount")]

        public async Task<IActionResult> GetAuthorCount()
        {
            var values = await _mediator.Send(new GetAuthorCountQuery());
            if (values != null)
            {
                return Ok(values);
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpGet("GetBlogCount")]

        public async Task<IActionResult> GetBlogCount()
        {
            var values = await _mediator.Send(new GetBlogCountQuery());
            if (values != null)
            {
                return Ok(values);
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpGet("GetBrandCount")]

        public async Task<IActionResult> GetBrandCount()
        {
            var values = await _mediator.Send(new GetBrandCountQuery());
            if (values != null)
            {
                return Ok(values);
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpGet("GetAvgRentPriceForDaily")]

        public async Task<IActionResult> GetAvgRentPriceForDaily()
        {
            var values = await _mediator.Send(new GetAvgRentPriceForDailyQuery());
            if (values != null)
            {
                return Ok(values);
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpGet("GetAvgRentPriceForWeekly")]

        public async Task<IActionResult> GetAvgRentPriceForWeekly()
        {
            var values = await _mediator.Send(new GetAvgRentPriceForWeeklyQuery());
            if (values != null)
            {
                return Ok(values);
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpGet("GetAvgRentPriceForMonthly")]

        public async Task<IActionResult> GetAvgRentPriceForMonthly()
        {
            var values = await _mediator.Send(new GetAvgRentPriceForMonthlyQuery());
            if (values != null)
            {
                return Ok(values);
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpGet("GetCarCountByTranmissionIsAuto")]

        public async Task<IActionResult> GetCarCountByTranmissionIsAuto()
        {
            var values = await _mediator.Send(new GetCarCountByTranmissionIsAutoQuery());
            if (values != null)
            {
                return Ok(values);
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpGet("GetBrandNameByMaxCar")]

        public async Task<IActionResult> GetBrandNameByMaxCar()
        {
            var values = await _mediator.Send(new GetBrandNameByMaxCarQuery());
            if (values != null)
            {
                return Ok(values);
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpGet("GetBlogTitleByMaxBlogComment")]

        public async Task<IActionResult> GetBlogTitleByMaxBlogComment()
        {
            var values = await _mediator.Send(new GetBlogTitleByMaxBlogCommentQuery());
            if (values != null)
            {
                return Ok(values);
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpGet("GetCarCountByKmSmallerThan1000")]

        public async Task<IActionResult> GetCarCountByKmSmallerThan1000()
        {
            var values = await _mediator.Send(new GetCarCountByKmSmallerThan1000Query());
            if (values != null)
            {
                return Ok(values);
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpGet("GetCarCountByFuelGasolineOrDiesel")]

        public async Task<IActionResult> GetCarCountByFuelGasolineOrDiesel()
        {
            var values = await _mediator.Send(new GetCarCountByFuelGasolineOrDieselQuery());
            if (values != null)
            {
                return Ok(values);
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpGet("GetCarCountByFuelElectric")]

        public async Task<IActionResult> GetCarCountByFuelElectric()
        {
            var values = await _mediator.Send(new GetCarCountByFuelElectricQuery());
            if (values != null)
            {
                return Ok(values);
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpGet("GetCarBrandAndModelByRentPriceDailyMax")]

        public async Task<IActionResult> GetCarBrandAndModelByRentPriceDailyMax()
        {
            var values = await _mediator.Send(new GetCarBrandAndModelByRentPriceDailyMaxQuery());
            if (values != null)
            {
                return Ok(values);
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpGet("GetCarBrandAndModelByRentPriceDailyMin")]

        public async Task<IActionResult> GetCarBrandAndModelByRentPriceDailyMin()
        {
            var values = await _mediator.Send(new GetCarBrandAndModelByRentPriceDailyMinQuery());
            if (values != null)
            {
                return Ok(values);
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpGet("GetLocationCount")]

        public async Task<IActionResult> GetLocationCount()
        {
            var values = await _mediator.Send(new GetLocationCountQuery());
            if (values != null)
            {
                return Ok(values);
            }
            else { return BadRequest("İşlem başarısız"); }
        }
    }
}
