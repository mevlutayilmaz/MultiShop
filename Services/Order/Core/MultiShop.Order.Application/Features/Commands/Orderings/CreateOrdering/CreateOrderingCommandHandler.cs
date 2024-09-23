using MediatR;
using MultiShop.Order.Application.Repositories;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Commands.Orderings.CreateOrdering
{
    public class CreateOrderingCommandHandler : IRequestHandler<CreateOrderingCommandRequest, CreateOrderingCommandResponse>
    {
        private readonly IWriteRepository<Ordering> _writeRepository;

        public CreateOrderingCommandHandler(IWriteRepository<Ordering> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<CreateOrderingCommandResponse> Handle(CreateOrderingCommandRequest request, CancellationToken cancellationToken)
        {
            await _writeRepository.AddAsync(new()
            {
                OrderDate = request.OrderDate,
                TotalPrice = request.TotalPrice,
                UserId = request.UserId,
                Completed = false,
            });
            await _writeRepository.SaveAsync();
            return new();
        }
    }
}
