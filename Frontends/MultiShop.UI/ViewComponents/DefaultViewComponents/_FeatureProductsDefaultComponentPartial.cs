using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CatalogDTOs.ProductDTOs;
using MultiShop.UI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;

namespace MultiShop.UI.ViewComponents.DefaultViewComponents
{
    public class _FeatureProductsDefaultComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

		public _FeatureProductsDefaultComponentPartial(IProductService productService)
		{
			_productService = productService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productService.GetAllProductsAsync();
            return View(values);
        }
    }
}
