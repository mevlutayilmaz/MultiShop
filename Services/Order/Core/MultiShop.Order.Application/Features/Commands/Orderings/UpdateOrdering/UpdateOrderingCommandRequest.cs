using MediatR;

namespace MultiShop.Order.Application.Features.Commands.Orderings.UpdateOrdering
{
    public class UpdateOrderingCommandRequest : IRequest<UpdateOrderingCommandResponse>
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}