namespace MultiShop.Basket.DTOs
{
    public class BasketTotalDTO
    {
        public string UserId { get; set; }
        public string DiscountCode { get; set; }
        public int DiscountRate { get; set; } = 0;
        public List<BasketItemDTO> BasketItems { get; set; }
        public decimal TotalPrice { get => BasketItems.Sum(bi => bi.Quantity * bi.Price); }
    }
}
