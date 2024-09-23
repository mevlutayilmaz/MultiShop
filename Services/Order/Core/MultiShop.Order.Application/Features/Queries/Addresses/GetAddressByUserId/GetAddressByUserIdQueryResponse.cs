﻿namespace MultiShop.Order.Application.Features.Queries.Addresses.GetAddressByUserId
{
    public class GetAddressByUserIdQueryResponse
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Detail { get; set; }
        public string ZipCode { get; set; }
    }
}