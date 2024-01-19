using CarBook.Application.Features.Commands.CategoryCommands;
using CarBook.Application.Features.Queries.CategoryQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

		[HttpGet("CategoryList")]

		public async Task<IActionResult> CategoryList()
        {
            var values = await _mediator.Send(new GetCategoryQuery());
            if (values != null)
            {
                return Ok(values);
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpGet("GetCategory")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var values = await _mediator.Send(new GetCategoryByIdQuery(id));
            if (values != null)
            {
                return Ok(values);
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            var values = await _mediator.Send(command);
            if (values == true)
            {
                return Ok("İşlem başarılı");
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpDelete("RemoveCategory")]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            var values = await _mediator.Send(new RemoveCategoryCommand(id));
            if (values == true)
            {
                return Ok("İşlem başarılı");
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
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
