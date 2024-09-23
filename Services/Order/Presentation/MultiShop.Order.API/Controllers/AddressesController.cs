using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Commands.Addresses.CreateAddress;
using MultiShop.Order.Application.Features.Commands.Addresses.RemoveAddress;
using MultiShop.Order.Application.Features.Commands.Addresses.UpdateAddress;
using MultiShop.Order.Application.Features.Queries.Addresses.GetAddressById;
using MultiShop.Order.Application.Features.Queries.Addresses.GetAddressByUserId;
using MultiShop.Order.Application.Features.Queries.Addresses.GetAddresses;

namespace MultiShop.Order.API.Controllers
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
        public async Task<IActionResult> GetAddresses([FromQuery] GetAddressesQueryRequest request)
        {
            List<GetAddressesQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAddressById([FromRoute] GetAddressByIdQueryRequest request)
        {
            GetAddressByIdQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAddressByUserId([FromQuery] GetAddressByUserIdQueryRequest request)
        {
            GetAddressByUserIdQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommandRequest request)
        {
            CreateAddressCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommandRequest request)
        {
            UpdateAddressCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAddress(RemoveAddressCommandRequest request)
        {
            RemoveAddressCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
