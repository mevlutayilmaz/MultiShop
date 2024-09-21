using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CatalogDTOs.ProductImageDTOs;
using MultiShop.UI.Services.CatalogServices.ProductImageServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/ProductImage")]
    public class ProductImageController : Controller
    {
        private readonly IProductImageService _productImageService;

		public ProductImageController(IProductImageService productImageService)
		{
			_productImageService = productImageService;
		}

		[Route("Index/{productId}")]
        public async Task<IActionResult> Index(string productId)
        {
			ProductImageViewbagList();
			ViewBag.productId = productId;
            TempData["ProductId"] = productId;

            var values = await _productImageService.GetByProductIdProductImageAsync(productId);
            return View(values);
        }

        [Route("CreateProductImage/{productId}")]
        public IActionResult CreateProductImage(string productId)
        {
			ProductImageViewbagList();
			return View();
        }

        [HttpPost]
        [Route("CreateProductImage/{productId}")]
        public async Task<IActionResult> CreateProductImage(string productId, CreateProductImageDTO createProductImageDTO)
        {
			await _productImageService.CreateProductImageAsync(createProductImageDTO);
			return RedirectToAction("Index", "ProductImage", new { area = "Admin", productId = productId });
		}

        [Route("DeleteProductImage/{id}")]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            await _productImageService.DeleteProductImageAsync(id);
			return RedirectToAction("Index", "ProductImage", new { area = "Admin", productId = TempData["ProductId"]?.ToString() });
		}

        [Route("UpdateProductImage/{id}")]
        public async Task<IActionResult> UpdateProductImage(string id)
        {
			ProductImageViewbagList();
            var values = await _productImageService.GetByIdProductImageAsync(id);
			return View(values);
		}

        [Route("UpdateProductImage/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDTO updateProductImageDTO)
        {
            await _productImageService.UpdateProductImageAsync(updateProductImageDTO);
			return RedirectToAction("Index", "ProductImage", new { area = "Admin", productId = updateProductImageDTO.ProductId });
		}

        void ProductImageViewbagList()
		{
			ViewBag.h1 = "Home";
			ViewBag.h2 = "Product Images";
			ViewBag.h3 = "Product Image List";
			ViewBag.h0 = "Product Image Operations";
		}
	}
}
