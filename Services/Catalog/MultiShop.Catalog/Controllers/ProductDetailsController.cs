using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.ProductDetailDTOs;
using MultiShop.Catalog.Services.ProductDetailServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailsController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var value = await _productDetailService.GetProductDetailsAsync();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailById(string id)
        {
            var value = await _productDetailService.GetByIdProductDetailAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDTO createProductDetailDTO)
        {
            await _productDetailService.CreateProductDetailAsync(createProductDetailDTO);
            return Ok("ProductDetail başarıyla eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDTO updateProductDetailDTO)
        {
            await _productDetailService.UpdateProductDetailAsync(updateProductDetailDTO);
            return Ok("ProductDetail başarıyla güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await _productDetailService.DeleteProductDetailAsync(id);
            return Ok("ProductDetail başarıyla silindi");
        }
    }
}
