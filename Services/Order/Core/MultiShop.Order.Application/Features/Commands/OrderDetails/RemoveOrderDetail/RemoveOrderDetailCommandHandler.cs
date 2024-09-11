using MediatR;
using MultiShop.Order.Application.Repositories;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Commands.OrderDetails.RemoveOrderDetail
{
    public class RemoveOrderDetailCommandHandler : IRequestHandler<RemoveOrderDetailCommandRequest, RemoveOrderDetailCommandResponse>
    {
        private readonly IWriteRepository<OrderDetail> _writeRepository;

        public RemoveOrderDetailCommandHandler(IWriteRepository<OrderDetail> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<RemoveOrderDetailCommandResponse> Handle(RemoveOrderDetailCommandRequest request, CancellationToken cancellationToken)
        {
            await _writeRepository.RemoveAsync(request.Id);
            await _writeRepository.SaveAsync();
            return new();
        }
    }
}
