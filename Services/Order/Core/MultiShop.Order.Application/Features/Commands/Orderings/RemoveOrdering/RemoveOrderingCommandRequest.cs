using MediatR;

namespace MultiShop.Order.Application.Features.Commands.Orderings.RemoveOrdering
{
    public class RemoveOrderingCommandRequest : IRequest<RemoveOrderingCommandResponse>
    {
        public string Id { get; set; }
    }
}