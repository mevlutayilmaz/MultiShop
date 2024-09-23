using MediatR;
using MultiShop.Order.Application.Repositories;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Queries.Orderings.GetOrderings
{
    public class GetOrderingsQueryHandler : IRequestHandler<GetOrderingsQueryRequest, List<GetOrderingsQueryResponse>>
    {
        private readonly IReadRepository<Ordering> _readRepository;

        public GetOrderingsQueryHandler(IReadRepository<Ordering> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<List<GetOrderingsQueryResponse>> Handle(GetOrderingsQueryRequest request, CancellationToken cancellationToken)
        {
            var datas = _readRepository.GetAll();
            return datas.Select(o => new GetOrderingsQueryResponse
            {
                Id = o.Id.ToString(),
                OrderDate = o.OrderDate,
                TotalPrice = o.TotalPrice,
                UserId = o.UserId,
                Completed = o.Completed,
            }).ToList();
        }
    }
}
