﻿using MediatR;

namespace MultiShop.Order.Application.Features.Queries.Addresses.GetAddressByUserId
{
    public class GetAddressByUserIdQueryRequest : IRequest<GetAddressByUserIdQueryResponse>
    {
        public string UserId { get; set; }
    }
}