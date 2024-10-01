namespace MultiShop.Catalog.DTOs.CategoryDTOs
{
    public class UpdateCategoryDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile? File { get; set; }

    }
}
