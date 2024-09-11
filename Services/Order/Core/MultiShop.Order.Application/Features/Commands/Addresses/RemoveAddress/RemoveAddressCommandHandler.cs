using MediatR;
using MultiShop.Order.Application.Repositories;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Commands.Addresses.RemoveAddress
{
    public class RemoveAddressCommandHandler : IRequestHandler<RemoveAddressCommandRequest, RemoveAddressCommandResponse>
    {
        private readonly IWriteRepository<Address> _writeRepository;

        public RemoveAddressCommandHandler(IWriteRepository<Address> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<RemoveAddressCommandResponse> Handle(RemoveAddressCommandRequest request, CancellationToken cancellationToken)
        {
            await _writeRepository.RemoveAsync(request.Id);
            await _writeRepository.SaveAsync();
            return new();
        }
    }
}
