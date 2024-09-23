using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Application.Repositories;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Queries.Orderings.GetOrderingByUserId
{
    public class GetOrderingByUserIdQueryHandler : IRequestHandler<GetOrderingByUserIdQueryRequest, List<GetOrderingByUserIdQueryResponse>>
    {
        private readonly IReadRepository<Ordering> _readRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetOrderingByUserIdQueryHandler(IReadRepository<Ordering> readRepository, IHttpContextAccessor httpContextAccessor)
        {
            _readRepository = readRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<GetOrderingByUserIdQueryResponse>> Handle(GetOrderingByUserIdQueryRequest request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst("sub").Value;
            return await _readRepository.Table.Where(o => o.UserId == userId).Select(o => new GetOrderingByUserIdQueryResponse()
            {
                Id = o.Id.ToString(),
                UserId = o.UserId,
                TotalPrice = o.TotalPrice,
                Completed = o.Completed,
                OrderDate = o.OrderDate,
            }).ToListAsync();
        }
    }
}
