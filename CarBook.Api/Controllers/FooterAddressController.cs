﻿using CarBook.Application.Features.Commands.FooterAddressCommands;
using CarBook.Application.Features.Queries.FooterAddressQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAddressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FooterAddressController(IMediator mediator)
        {
            _mediator = mediator;
        }


		[HttpGet("FooterAddressList")]
		public async Task<IActionResult> FooterAddressList()
        {
            var values = await _mediator.Send(new GetFooterAddressQuery());
            if (values != null)
            {
                return Ok(values);
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpGet("GetFooterAddress")]
        public async Task<IActionResult> GetFooterAddress(int id)
        {
            var values = await _mediator.Send(new GetFooterAddressByIdQuery(id));
            if (values != null)
            {
                return Ok(values);
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpPost("CreateFooterAddress")]
        public async Task<IActionResult> CreateFooterAddress(CreateFooterAddressCommand command)
        {
            var values = await _mediator.Send(command);
            if (values == true)
            {
                return Ok("İşlem başarılı");
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpDelete("RemoveFooterAddress")]
        public async Task<IActionResult> RemoveFooterAddress(int id)
        {
            var values = await _mediator.Send(new RemoveFooterAddressCommand(id));
            if (values == true)
            {
                return Ok("İşlem başarılı");
            }
            else { return BadRequest("İşlem başarısız"); }
        }

        [HttpPut("UpdateFooterAddress")]
        public async Task<IActionResult> UpdateFooterAddress(UpdateFooterAddressCommand command)
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
