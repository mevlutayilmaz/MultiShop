using MediatR;
using MultiShop.Order.Application.Repositories;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Commands.OrderDetails.UpdateOrderDetail
{
    public class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommandRequest, UpdateOrderDetailCommandResponse>
    {
        private readonly IWriteRepository<OrderDetail> _writeRepository;

        public UpdateOrderDetailCommandHandler(IWriteRepository<OrderDetail> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<UpdateOrderDetailCommandResponse> Handle(UpdateOrderDetailCommandRequest request, CancellationToken cancellationToken)
        {
            _writeRepository.Update(new()
            {
                Id = Guid.Parse(request.Id),
                OrderingId = request.OrderingId,
                ProductId = request.ProductId,
                ProductName = request.ProductName,
                ProductPrice = request.ProductPrice,
                Quantity = request.Quantity,
                TotalPrice = request.TotalPrice
            });
            await _writeRepository.SaveAsync();
            return new();
        }
    }
}
