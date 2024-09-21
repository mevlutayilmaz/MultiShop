using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DTOLayer.CatalogDTOs.CategoryDTOs;
using MultiShop.DTOLayer.CatalogDTOs.ProductDTOs;
using MultiShop.UI.Services.CatalogServices.CategoryServices;
using MultiShop.UI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

		public ProductController(IProductService productService, ICategoryService categoryService)
		{
			_productService = productService;
			_categoryService = categoryService;
		}

		[Route("Index")]
        public async Task<IActionResult> Index()
        {
            ProductViewbagList();
            var values = await _productService.GetProductsWithCategoryAsync();
            return View(values);
        }

        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct()
        {
            var categories = await _categoryService.GetAllCategoryAsync();
            List<SelectListItem> categoryValues = (from x in categories
												   select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.Id
                                                   }).ToList();
            ViewBag.CategoryValues = categoryValues;
            return View();
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDTO createProductDTO)
        {
            await _productService.CreateProductAsync(createProductDTO);
			return RedirectToAction("Index", "Product", new { area = "Admin" });
        }

        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
			await _productService.DeleteProductAsync(id);
			return RedirectToAction("Index", "Product", new { area = "Admin" });
        }

        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            ProductViewbagList();
			var categories = await _categoryService.GetAllCategoryAsync();
			List<SelectListItem> categoryValues = (from x in categories
												   select new SelectListItem
												   {
													   Text = x.Name,
													   Value = x.Id
												   }).ToList();
			ViewBag.CategoryValues = categoryValues;

			var values = await _productService.GetByIdProductAsync(id);
            return View(values);
        }

        [Route("UpdateProduct/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDTO updateProductDTO)
        {
            await _productService.UpdateProductAsync(updateProductDTO);
			return RedirectToAction("Index", "Product", new { area = "Admin" });
		}

		void ProductViewbagList()
		{
			ViewBag.h1 = "Home";
			ViewBag.h2 = "Products";
			ViewBag.h3 = "Product List";
			ViewBag.h0 = "Product Operations";
		}
	}
}
