using MediatR;
using MultiShop.Order.Application.Repositories;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Queries.OrderDetails.GetOrderDetailById
{
    public class GetOrderDetailByIdQueryHandler : IRequestHandler<GetOrderDetailByIdQueryRequest, GetOrderDetailByIdQueryResponse>
    {
        private readonly IReadRepository<OrderDetail> _readRepository;

        public GetOrderDetailByIdQueryHandler(IReadRepository<OrderDetail> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<GetOrderDetailByIdQueryResponse> Handle(GetOrderDetailByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _readRepository.GetByIdAsync(request.Id);
            return new()
            {
                Id = data.Id.ToString(),
                OrderingId = data.OrderingId,
                ProductId = data.ProductId,
                ProductName = data.ProductName,
                ProductPrice = data.ProductPrice,
                Quantity = data.Quantity,
                TotalPrice = data.TotalPrice,
            };
        }
    }
}
