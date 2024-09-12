using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Commands.OrderDetails.CreateOrderDetail;
using MultiShop.Order.Application.Features.Commands.OrderDetails.RemoveOrderDetail;
using MultiShop.Order.Application.Features.Commands.OrderDetails.UpdateOrderDetail;
using MultiShop.Order.Application.Features.Queries.OrderDetails.GetOrderDetailById;
using MultiShop.Order.Application.Features.Queries.OrderDetails.GetOrderDetails;

namespace MultiShop.Order.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderDetailsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderDetails([FromQuery] GetOrderDetailsQueryRequest request)
        {
            List<GetOrderDetailsQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetOrderDetailById([FromRoute] GetOrderDetailByIdQueryRequest request)
        {
            GetOrderDetailByIdQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommandRequest request)
        {
            CreateOrderDetailCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommandRequest request)
        {
            UpdateOrderDetailCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrderDetail(RemoveOrderDetailCommandRequest request)
        {
            RemoveOrderDetailCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
