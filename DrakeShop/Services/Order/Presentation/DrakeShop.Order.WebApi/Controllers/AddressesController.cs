﻿using DrakeShop.Order.Application.Features.Mediator.Commands.AddressCommands;
using DrakeShop.Order.Application.Features.Mediator.Queries.AddressQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrakeShop.Order.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddressesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> AddressList()
        {

            var values = await _mediator.Send(new GetAddressQuery());

            return Ok(values);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressById(int id)
        {

            var values = await _mediator.Send(new GetAddressByIdQuery(id));

            return Ok(values);

        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
        {

            await _mediator.Send(command);

            return Ok("Adres Başarıyla Eklendi.");

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAddress(int id)
        {

            await _mediator.Send(new DeleteAddressCommand(id));

            return Ok("Adres Başarıyla Silindi.");

        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand command)
        {

            await _mediator.Send(command);

            return Ok("Adres Başarıyla Güncellendi.");

        }
    }
}
