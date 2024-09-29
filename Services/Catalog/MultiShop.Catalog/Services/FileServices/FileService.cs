
using System.Net.Http.Headers;

namespace MultiShop.Catalog.Services.FileServices
{
    public class FileService : IFileService
    {
        private readonly HttpClient _httpClient;

        public FileService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<string>> UplodCategoryImagesAsync(IFormFileCollection files)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync("http://localhost:7207/api/images/UploadCategoryImages", files);
            return await responseMessage.Content.ReadFromJsonAsync<List<string>>();
        }

        public async Task<List<string>> UplodProductImagesAsync(IFormFileCollection files)
        {
            using var content = new MultipartFormDataContent();

            // Dosyaları MultipartFormDataContent içine ekleyin
            foreach (var file in files)
            {
                var stream = file.OpenReadStream();
                var fileContent = new StreamContent(stream);
                fileContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
                content.Add(fileContent, "files", file.FileName);
            }

            var responseMessage = await _httpClient.PostAsync("http://localhost:7207/api/images/UploadProductImages", content);
            var value = await responseMessage.Content.ReadFromJsonAsync<List<string>>();
            return value;
        }
    }
}
