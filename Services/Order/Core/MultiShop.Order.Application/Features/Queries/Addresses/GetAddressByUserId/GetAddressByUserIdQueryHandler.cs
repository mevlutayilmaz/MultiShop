﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Application.Repositories;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Queries.Addresses.GetAddressByUserId
{
    public class GetAddressByUserIdQueryHandler : IRequestHandler<GetAddressByUserIdQueryRequest, GetAddressByUserIdQueryResponse>
    {
        private readonly IReadRepository<Address> _readRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetAddressByUserIdQueryHandler(IReadRepository<Address> readRepository, IHttpContextAccessor httpContextAccessor)
        {
            _readRepository = readRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<GetAddressByUserIdQueryResponse> Handle(GetAddressByUserIdQueryRequest request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst("sub").Value;
            var address = await _readRepository.Table.FirstOrDefaultAsync(a => a.UserId == userId);
            return new()
            {
                Id = address.Id.ToString(),
                UserId = userId,
                FirstName = address.FirstName,
                LastName = address.LastName,
                Email = address.Email,
                PhoneNumber = address.PhoneNumber,
                Country = address.Country,
                City = address.City,
                District = address.District,
                Detail = address.Detail,
                ZipCode = address.ZipCode
            };
        }
    }
}
