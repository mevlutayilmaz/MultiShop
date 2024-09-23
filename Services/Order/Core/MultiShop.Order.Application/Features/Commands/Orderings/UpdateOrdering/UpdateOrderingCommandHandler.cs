using MediatR;
using MultiShop.Order.Application.Repositories;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Commands.Orderings.UpdateOrdering
{
    public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommandRequest, UpdateOrderingCommandResponse>
    {
        private readonly IWriteRepository<Ordering> _writeRepository;

        public UpdateOrderingCommandHandler(IWriteRepository<Ordering> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<UpdateOrderingCommandResponse> Handle(UpdateOrderingCommandRequest request, CancellationToken cancellationToken)
        {
            _writeRepository.Update(new()
            {
                Id = Guid.Parse(request.Id),
                OrderDate = request.OrderDate,
                TotalPrice = request.TotalPrice,
                UserId = request.UserId,
                Completed = request.Completed,
            });
            await _writeRepository.SaveAsync();
            return new();
        }
    }
}
