using CarBook.Application.Features.Commands.CarCommands;
using CarBook.Application.Features.Commands.ReviewCommands;
using CarBook.Application.Features.Queries.AuthorQueries;
using CarBook.Application.Features.Queries.ReviewQueries;
using FluentValidation;
using FluentValidation.Results;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReviewController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly IValidator<CreateReviewCommand> _validatorCreate;
		private readonly IValidator<UpdateReviewCommand> _validatorUpdate;

		public ReviewController(IMediator mediator, IValidator<CreateReviewCommand> validatorCreate, IValidator<UpdateReviewCommand> validatorUpdate)
		{
			_mediator = mediator;
			_validatorCreate = validatorCreate;
			_validatorUpdate = validatorUpdate;
		}

		[HttpGet("GetReviewsByCarId")]
		public async Task<IActionResult> GetReviewsByCarId(int id)
		{
			var values = await _mediator.Send(new GetReviewByCarIdQuery(id));
			if (values != null)
			{
				return Ok(values);
			}
			else { return BadRequest("İşlem başarısız"); }
		}

		[HttpPost("CreateReview")]

		public async Task<IActionResult> CreateReview(CreateReviewCommand command)
		{
			ValidationResult validationResult = await _validatorCreate.ValidateAsync(command);
			if (!validationResult.IsValid) 
			{
				return BadRequest(validationResult.Errors);
			}
			else
			{
				var values = await _mediator.Send(command);
				if (values == true)
				{
					return Ok("İşlem başarılı");
				}
				else
				{
					return BadRequest("İşlem başarısız");
				}
			}
		}

		[HttpDelete("RemoveReview")]
		public async Task<IActionResult> RemoveReview(int id)
		{
			var values = await _mediator.Send(new RemoveReviewCommand(id));
			if (values == true)
			{
				return Ok("İşlem başarılı");
			}
			else { return BadRequest("İşlem başarısız"); }
		}

		[HttpPut("UpdateReview")]
		public async Task<IActionResult> UpdateReview(UpdateReviewCommand command)
		{
			ValidationResult validationResult = await _validatorUpdate.ValidateAsync(command);
			if (!validationResult.IsValid)
			{
				return BadRequest(validationResult.Errors);
			}
			else
			{
				var values = await _mediator.Send(command);
				if (values == true)
				{
					return Ok("İşlem başarılı");
				}
				else
				{
					return BadRequest("İşlem başarısız");
				}
			}
		}
	}
}
