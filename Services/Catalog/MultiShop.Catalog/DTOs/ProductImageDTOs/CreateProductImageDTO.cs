namespace MultiShop.Catalog.DTOs.ProductImageDTOs
{
    public class CreateProductImageDTO
    {
        public IFormFileCollection Files { get; set; }
        public string ProductId { get; set; }
    }
}
