﻿namespace MultiShop.Catalog.DTOs.ProductDTOs
{
    public class UpdateProductDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        public IFormFile? File { get; set; }
    }
}
