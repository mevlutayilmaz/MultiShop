﻿namespace MultiShop.Order.Application.Features.Queries.Addresses.GetAddressById
{
    public class GetAddressByIdQueryResponse
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Detail { get; set; }
    }
}