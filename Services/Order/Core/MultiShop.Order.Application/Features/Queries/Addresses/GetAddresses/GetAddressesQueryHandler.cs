using MediatR;
using MultiShop.Order.Application.Repositories;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Queries.Addresses.GetAddresses
{
    public class GetAddressesQueryHandler : IRequestHandler<GetAddressesQueryRequest, List<GetAddressesQueryResponse>>
    {
        private readonly IReadRepository<Address> _readRepository;

        public GetAddressesQueryHandler(IReadRepository<Address> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<List<GetAddressesQueryResponse>> Handle(GetAddressesQueryRequest request, CancellationToken cancellationToken)
        {
            var datas = _readRepository.GetAll();
            return datas.Select(a => new GetAddressesQueryResponse
            {
                Id = a.Id.ToString(),
                City = a.City,
                Detail = a.Detail,
                District = a.District,
                UserId = a.UserId,
            }).ToList();
        }
    }
}
