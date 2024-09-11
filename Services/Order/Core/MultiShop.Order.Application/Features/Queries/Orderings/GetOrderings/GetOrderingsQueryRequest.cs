using MediatR;

namespace MultiShop.Order.Application.Features.Queries.Orderings.GetOrderings
{
    public class GetOrderingsQueryRequest : IRequest<List<GetOrderingsQueryResponse>>
    {
    }
}