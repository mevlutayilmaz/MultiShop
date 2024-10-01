using Microsoft.AspNetCore.Http;

namespace MultiShop.DTOLayer.CatalogDTOs.ProductImageDTOs
{
    public class CreateProductImageDTO
    {
        public string ProductId { get; set; }
        public IFormFileCollection Files { get; set; }
    }
}
