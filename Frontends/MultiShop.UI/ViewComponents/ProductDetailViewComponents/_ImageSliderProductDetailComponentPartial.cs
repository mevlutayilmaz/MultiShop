using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CatalogDTOs.ProductImageDTOs;
using MultiShop.UI.Services.CatalogServices.ProductImageServices;
using Newtonsoft.Json;

namespace MultiShop.UI.ViewComponents.ProductDetailViewComponents
{
    public class _ImageSliderProductDetailComponentPartial : ViewComponent
    {
        private readonly IProductImageService _productImageService;

		public _ImageSliderProductDetailComponentPartial(IProductImageService productImageService)
		{
			_productImageService = productImageService;
		}

		public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _productImageService.GetByProductIdProductImageAsync(id);
            return View(values);
        }
    }
}
