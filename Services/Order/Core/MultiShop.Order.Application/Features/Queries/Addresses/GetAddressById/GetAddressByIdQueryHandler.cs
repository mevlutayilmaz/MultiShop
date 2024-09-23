using MediatR;
using MultiShop.Order.Application.Repositories;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Queries.Addresses.GetAddressById
{
    public class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQueryRequest, GetAddressByIdQueryResponse>
    {
        private readonly IReadRepository<Address> _readRepository;

        public GetAddressByIdQueryHandler(IReadRepository<Address> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<GetAddressByIdQueryResponse> Handle(GetAddressByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _readRepository.GetByIdAsync(request.Id);
            return new()
            {
                Id = data.Id.ToString(),
                UserId = data.UserId,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
                PhoneNumber = data.PhoneNumber,
                Country = data.Country,
                City = data.City,
                District = data.District,
                Detail = data.Detail,
                ZipCode = data.ZipCode,
            };
        }
    }
}
