using MediatR;

namespace MultiShop.Order.Application.Features.Queries.Addresses.GetAddressById
{
    public class GetAddressByIdQueryRequest : IRequest<GetAddressByIdQueryResponse>
    {
        public string Id { get; set; }
    }
}