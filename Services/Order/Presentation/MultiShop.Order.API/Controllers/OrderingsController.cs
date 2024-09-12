using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Commands.Orderings.CreateOrdering;
using MultiShop.Order.Application.Features.Commands.Orderings.RemoveOrdering;
using MultiShop.Order.Application.Features.Commands.Orderings.UpdateOrdering;
using MultiShop.Order.Application.Features.Queries.Orderings.GetOrderingById;
using MultiShop.Order.Application.Features.Queries.Orderings.GetOrderings;

namespace MultiShop.Order.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderings([FromQuery] GetOrderingsQueryRequest request)
        {
            List<GetOrderingsQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetOrderingById([FromRoute] GetOrderingByIdQueryRequest request)
        {
            GetOrderingByIdQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrdering(CreateOrderingCommandRequest request)
        {
            CreateOrderingCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommandRequest request)
        {
            UpdateOrderingCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrdering(RemoveOrderingCommandRequest request)
        {
            RemoveOrderingCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
