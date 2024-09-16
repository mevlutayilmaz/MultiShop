using MultiShop.Catalog.DTOs.CategoryDTOs;

namespace MultiShop.Catalog.DTOs.ProductDTOs
{
    public class ResultProductWithCategoryDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public ResultCategoryDTO Category { get; set; }
    }
}
