using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CatalogDTOs.ProductDetailDTOs;
using MultiShop.UI.Services.CatalogServices.ProductDetailServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/ProductDetail")]
    public class ProductDetailController : Controller
    {
        private readonly IProductDetailService _productDetailService;

		public ProductDetailController(IProductDetailService productDetailService)
		{
			_productDetailService = productDetailService;
		}

		[Route("UpdateProductDetail/{productId}")]
        public async Task<IActionResult> UpdateProductDetail(string productId)
        {
            ProductDetailViewbagList();
            var values = await _productDetailService.GetByProductIdProductDetailAsync(productId);
            return View(values);
        }

        [Route("UpdateProductDetail/{productId}")]
        [HttpPost]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDTO updateProductDetailDTO)
        {
            await _productDetailService.UpdateProductDetailAsync(updateProductDetailDTO);
			return RedirectToAction("Index", "Product", new { area = "Admin" });
		}

		void ProductDetailViewbagList()
		{
			ViewBag.h1 = "Home";
			ViewBag.h2 = "Product Details";
			ViewBag.h3 = "Product Detail List";
			ViewBag.h0 = "Product Detail Operations";
		}
	}
}
