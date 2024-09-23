using MediatR;
using MultiShop.Order.Application.Repositories;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Queries.Orderings.GetOrderingById
{
    public class GetOrderingByIdQueryHandler : IRequestHandler<GetOrderingByIdQueryRequest, GetOrderingByIdQueryResponse>
    {
        private readonly IReadRepository<Ordering> _readRepository;

        public GetOrderingByIdQueryHandler(IReadRepository<Ordering> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<GetOrderingByIdQueryResponse> Handle(GetOrderingByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _readRepository.GetByIdAsync(request.Id);
            return new()
            {
                Id = data.Id.ToString(),
                OrderDate = data.OrderDate,
                TotalPrice = data.TotalPrice,
                UserId = data.UserId,
                Completed = data.Completed,
            };
        }
    }
}
