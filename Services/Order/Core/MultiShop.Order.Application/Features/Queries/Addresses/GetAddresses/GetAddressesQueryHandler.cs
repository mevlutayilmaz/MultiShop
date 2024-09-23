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
                UserId = a.UserId,
                FirstName = a.FirstName,
                LastName = a.LastName,
                Email = a.Email,
                PhoneNumber = a.PhoneNumber,
                Country = a.Country,
                City = a.City,
                District = a.District,
                Detail = a.Detail,
                ZipCode = a.ZipCode,
            }).ToList();
        }
    }
}
