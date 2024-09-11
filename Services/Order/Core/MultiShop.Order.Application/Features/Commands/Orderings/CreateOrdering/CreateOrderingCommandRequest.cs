using MediatR;

namespace MultiShop.Order.Application.Features.Commands.Orderings.CreateOrdering
{
    public class CreateOrderingCommandRequest : IRequest<CreateOrderingCommandResponse>
    {
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}