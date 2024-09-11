using MediatR;

namespace MultiShop.Order.Application.Features.Queries.Orderings.GetOrderingById
{
    public class GetOrderingByIdQueryRequest : IRequest<GetOrderingByIdQueryResponse>
    {
        public string Id { get; set; }
    }
}