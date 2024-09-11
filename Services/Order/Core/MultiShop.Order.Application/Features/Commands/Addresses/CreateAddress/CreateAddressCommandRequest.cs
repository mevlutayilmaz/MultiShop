using MediatR;

namespace MultiShop.Order.Application.Features.Commands.Addresses.CreateAddressCommand
{
    public class CreateAddressCommandRequest : IRequest<CreateAddressCommandResponse>
    {
        public string UserId { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Detail { get; set; }
    }
}