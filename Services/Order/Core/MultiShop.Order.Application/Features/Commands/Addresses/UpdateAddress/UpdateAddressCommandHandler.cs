using MediatR;
using MultiShop.Order.Application.Repositories;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Commands.Addresses.UpdateAddress
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommandRequest, UpdateAddressCommandResponse>
    {
        private readonly IWriteRepository<Address> _writeRepository;

        public UpdateAddressCommandHandler(IWriteRepository<Address> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<UpdateAddressCommandResponse> Handle(UpdateAddressCommandRequest request, CancellationToken cancellationToken)
        {
            _writeRepository.Update(new()
            {
                Id = Guid.Parse(request.Id),
                UserId = request.UserId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Country = request.Country,
                City = request.City,
                District = request.District,
                Detail = request.Detail,
                ZipCode = request.ZipCode
            });

            await _writeRepository.SaveAsync();
            return new();
        }
    }
}
