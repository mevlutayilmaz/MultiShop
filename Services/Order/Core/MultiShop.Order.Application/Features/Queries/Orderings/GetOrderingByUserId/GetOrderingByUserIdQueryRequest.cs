using MediatR;

namespace MultiShop.Order.Application.Features.Queries.Orderings.GetOrderingByUserId
{
    public class GetOrderingByUserIdQueryRequest : IRequest<List<GetOrderingByUserIdQueryResponse>>
    {
    }
}