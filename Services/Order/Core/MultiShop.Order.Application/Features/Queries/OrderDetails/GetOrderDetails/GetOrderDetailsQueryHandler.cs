using MediatR;
using MultiShop.Order.Application.Repositories;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Queries.OrderDetails.GetOrderDetails
{
    public class GetOrderDetailsQueryHandler : IRequestHandler<GetOrderDetailsQueryRequest, List<GetOrderDetailsQueryResponse>>
    {
        private readonly IReadRepository<OrderDetail> _readRepository;

        public GetOrderDetailsQueryHandler(IReadRepository<OrderDetail> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<List<GetOrderDetailsQueryResponse>> Handle(GetOrderDetailsQueryRequest request, CancellationToken cancellationToken)
        {
            var datas = _readRepository.GetAll();
            return datas.Select(od => new GetOrderDetailsQueryResponse
            {
                Id = od.Id.ToString(),
                OrderingId = od.OrderingId,
                ProductId = od.ProductId,
                ProductName = od.ProductName,
                ProductPrice = od.ProductPrice,
                Quantity = od.Quantity,
                TotalPrice = od.TotalPrice,
            }).ToList();
        }
    }
}
