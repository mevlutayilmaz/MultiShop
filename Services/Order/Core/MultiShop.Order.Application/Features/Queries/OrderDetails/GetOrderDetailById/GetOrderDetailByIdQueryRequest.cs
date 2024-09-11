using MediatR;

namespace MultiShop.Order.Application.Features.Queries.OrderDetails.GetOrderDetailById
{
    public class GetOrderDetailByIdQueryRequest : IRequest<GetOrderDetailByIdQueryResponse>
    {
        public string Id { get; set; }
    }
}