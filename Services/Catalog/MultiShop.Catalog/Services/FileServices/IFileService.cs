namespace MultiShop.Catalog.Services.FileServices
{
    public interface IFileService
    {
        Task<List<string>> UplodCategoryImagesAsync(IFormFileCollection files);
        Task<List<string>> UplodProductImagesAsync(IFormFileCollection files);
    }
}
