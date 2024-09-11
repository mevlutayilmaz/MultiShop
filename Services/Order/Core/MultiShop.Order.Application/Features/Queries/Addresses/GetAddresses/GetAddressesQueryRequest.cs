using MediatR;

namespace MultiShop.Order.Application.Features.Queries.Addresses.GetAddresses
{
    public class GetAddressesQueryRequest : IRequest<List<GetAddressesQueryResponse>>
    {
    }
}