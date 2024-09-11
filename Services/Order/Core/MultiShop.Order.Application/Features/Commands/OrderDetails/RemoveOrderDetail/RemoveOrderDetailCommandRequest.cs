using MediatR;

namespace MultiShop.Order.Application.Features.Commands.OrderDetails.RemoveOrderDetail
{
    public class RemoveOrderDetailCommandRequest : IRequest<RemoveOrderDetailCommandResponse>
    {
        public string Id { get; set; }
    }
}