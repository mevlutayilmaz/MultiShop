using MediatR;
using Microsoft.AspNetCore.Http;
using MultiShop.Order.Application.Repositories;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Commands.Addresses.CreateAddress
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommandRequest, CreateAddressCommandResponse>
    {
        private readonly IWriteRepository<Address> _writeRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateAddressCommandHandler(IWriteRepository<Address> writeRepository, IHttpContextAccessor httpContextAccessor)
        {
            _writeRepository = writeRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<CreateAddressCommandResponse> Handle(CreateAddressCommandRequest request, CancellationToken cancellationToken)
        {
            await _writeRepository.AddAsync(new()
            {
                UserId = _httpContextAccessor.HttpContext.User.FindFirst("sub").Value,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Country = request.Country,
                City = request.City,
                District = request.District,
                ZipCode = request.ZipCode,
                Detail = request.Detail
            });
            await _writeRepository.SaveAsync();
            return new();
        }
    }
}
