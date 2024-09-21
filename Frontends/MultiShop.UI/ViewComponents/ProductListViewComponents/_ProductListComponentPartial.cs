using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CatalogDTOs.ProductDTOs;
using MultiShop.UI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;

namespace MultiShop.UI.ViewComponents.ProductListViewComponents
{
    public class _ProductListComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

		public _ProductListComponentPartial(IProductService productService)
		{
			_productService = productService;
		}

		public async Task<IViewComponentResult> InvokeAsync(string categoryId)
        {
            var values = await _productService.GetProductsByCategoryIdAsync(categoryId);
            return View(values);
        }
    }
}
