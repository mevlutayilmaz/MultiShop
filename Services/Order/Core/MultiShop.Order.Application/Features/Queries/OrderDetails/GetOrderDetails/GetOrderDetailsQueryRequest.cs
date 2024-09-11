using MediatR;

namespace MultiShop.Order.Application.Features.Queries.OrderDetails.GetOrderDetails
{
    public class GetOrderDetailsQueryRequest : IRequest<List<GetOrderDetailsQueryResponse>>
    {
    }
}