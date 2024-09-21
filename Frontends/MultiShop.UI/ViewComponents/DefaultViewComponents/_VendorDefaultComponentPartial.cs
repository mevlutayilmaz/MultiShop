using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CatalogDTOs.BrandDTOs;
using MultiShop.UI.Services.CatalogServices.BrandServices;
using Newtonsoft.Json;

namespace MultiShop.UI.ViewComponents.DefaultViewComponents
{
    public class _VendorDefaultComponentPartial : ViewComponent
    {
        private readonly IBrandService _brandService;

		public _VendorDefaultComponentPartial(IBrandService brandService)
		{
			_brandService = brandService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _brandService.GetAllBrandsAsync();
            return View(values);
        }
    }
}
