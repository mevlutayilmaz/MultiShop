using MediatR;
using MultiShop.Order.Application.Repositories;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Commands.OrderDetails.CreateOrderDetail
{
    public class CreateOrderDetailHandler : IRequestHandler<CreateOrderDetailRequest, CreateOrderDetailResponse>
    {
        private readonly IWriteRepository<OrderDetail> _writeRepository;

        public CreateOrderDetailHandler(IWriteRepository<OrderDetail> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<CreateOrderDetailResponse> Handle(CreateOrderDetailRequest request, CancellationToken cancellationToken)
        {
            await _writeRepository.AddAsync(new()
            {
                ProductId = request.ProductId,
                ProductName = request.ProductName,
                ProductPrice = request.ProductPrice,
                OrderingId = request.OrderingId,
                Quantity = request.Quantity,
                TotalPrice = request.TotalPrice,
            });
            await _writeRepository.SaveAsync();
            return new();
        }
    }
}
