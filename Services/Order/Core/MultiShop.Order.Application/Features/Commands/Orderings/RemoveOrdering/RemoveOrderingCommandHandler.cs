using MediatR;
using MultiShop.Order.Application.Repositories;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Commands.Orderings.RemoveOrdering
{
    public class RemoveOrderingCommandHandler : IRequestHandler<RemoveOrderingCommandRequest, RemoveOrderingCommandResponse>
    {
        private readonly IWriteRepository<Ordering> _writeRepository;

        public RemoveOrderingCommandHandler(IWriteRepository<Ordering> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<RemoveOrderingCommandResponse> Handle(RemoveOrderingCommandRequest request, CancellationToken cancellationToken)
        {
            await _writeRepository.RemoveAsync(request.Id);
            await _writeRepository.SaveAsync();
            return new();
        }
    }
}
