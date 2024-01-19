using CarBook.Application.Features.Commands.TagCloudCommands;
using CarBook.Application.Features.Queries.TagCloudQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagCloudController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagCloudController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("TagCloudList")]
        public async Task<IActionResult> TagCloudList()
        {
            var values = await _mediator.Send(new GetTagCloudQuery());
            if (values != null)
            {
                return Ok(values);
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpGet("TagCloudByBlogId")]
        public async Task<IActionResult> TagCloudByBlogId(int id)
        {
            var values = await _mediator.Send(new GetTagCloudByBlogIdQuery(id));
            if (values != null)
            {
                return Ok(values);
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpGet("GetTagCloud")]
        public async Task<IActionResult> GetTagCloud(int id)
        {
            var values = await _mediator.Send(new GetTagCloudByIdQuery(id));
            if (values != null)
            {
                return Ok(values);
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpPost("CreateTagCloud")]
        public async Task<IActionResult> CreateTagCloud(CreateTagCloudCommand command)
        {
            var values = await _mediator.Send(command);
            if (values == true)
            {
                return Ok("İşlem başarılı");
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpDelete("RemoveTagCloud")]
        public async Task<IActionResult> RemoveTagCloud(int id)
        {
            var values = await _mediator.Send(new RemoveTagCloudCommand(id));
            if (values == true)
            {
                return Ok("İşlem başarılı");
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpPut("UpdateTagCloud")]
        public async Task<IActionResult> UpdateTagCloud(UpdateTagCloudCommand command)
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
