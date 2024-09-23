using MediatR;

namespace MultiShop.Order.Application.Features.Commands.Addresses.CreateAddress
{
    public class CreateAddressCommandRequest : IRequest<CreateAddressCommandResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Detail { get; set; }
        public string ZipCode { get; set; }
    }
}