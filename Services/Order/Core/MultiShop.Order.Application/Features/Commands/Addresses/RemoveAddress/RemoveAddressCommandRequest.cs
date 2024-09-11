using MediatR;

namespace MultiShop.Order.Application.Features.Commands.Addresses.RemoveAddress
{
    public class RemoveAddressCommandRequest : IRequest<RemoveAddressCommandResponse>
    {
        public string Id { get; set; }
    }
}