﻿namespace MultiShop.Basket.DTOs
{
    public class BasketItemDTO
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
