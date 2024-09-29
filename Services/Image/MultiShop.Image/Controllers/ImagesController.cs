using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Image.Services.Storage;

namespace MultiShop.Image.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        readonly IStorageService _storageService;

        public ImagesController(IStorageService storageService)
        {
            _storageService = storageService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UploadProductImages([FromForm] IFormFileCollection files)
        {
            var result = await _storageService.UploadAsync("product-images", files);
            var filePaths = result.Select(x => x.pathOrContainerName).ToList();
            return Ok(filePaths);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UploadCategoryImages(IFormFileCollection files)
        {
            var result = await _storageService.UploadAsync("category-images", files);
            var filePaths = result.Select(x => x.pathOrContainerName).ToList();
            return Ok(filePaths);
        }
    }
}
