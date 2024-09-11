using MediatR;

namespace MultiShop.Order.Application.Features.Commands.OrderDetails.UpdateOrderDetail
{
    public class UpdateOrderDetailCommandRequest : IRequest<UpdateOrderDetailCommandResponse>
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public string OrderingId { get; set; }
    }
}