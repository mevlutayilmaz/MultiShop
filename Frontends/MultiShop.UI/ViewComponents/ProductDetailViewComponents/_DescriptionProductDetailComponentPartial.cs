using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CatalogDTOs.ProductDetailDTOs;
using MultiShop.UI.Services.CatalogServices.ProductDetailServices;
using Newtonsoft.Json;

namespace MultiShop.UI.ViewComponents.ProductDetailViewComponents
{
    public class _DescriptionProductDetailComponentPartial : ViewComponent
    {
        private readonly IProductDetailService _productDetailService;

		public _DescriptionProductDetailComponentPartial(IProductDetailService productDetailService)
		{
			_productDetailService = productDetailService;
		}

		public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _productDetailService.GetByProductIdProductDetailAsync(id);
            return View(values);
        }
    }
}
