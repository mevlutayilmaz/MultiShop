using MediatR;
using MultiShop.Order.Application.Repositories;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Commands.Addresses.CreateAddress
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommandRequest, CreateAddressCommandResponse>
    {
        private readonly IWriteRepository<Address> _writeRepository;

        public CreateAddressCommandHandler(IWriteRepository<Address> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<CreateAddressCommandResponse> Handle(CreateAddressCommandRequest request, CancellationToken cancellationToken)
        {
            await _writeRepository.AddAsync(new()
            {
                City = request.City,
                Detail = request.Detail,
                District = request.District,
                UserId = request.UserId,
            });
            await _writeRepository.SaveAsync();
            return new();
        }
    }
}
