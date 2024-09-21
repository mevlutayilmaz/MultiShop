using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CatalogDTOs.FeatureSliderDTOs;
using MultiShop.UI.Services.CatalogServices.FeatureSliderServices;
using Newtonsoft.Json;

namespace MultiShop.UI.ViewComponents.DefaultViewComponents
{
    public class _CarouselDefaultComponentPartial : ViewComponent
    {
        private readonly IFeatureSliderService _featureSliderService;

		public _CarouselDefaultComponentPartial(IFeatureSliderService featureSliderService)
		{
			_featureSliderService = featureSliderService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _featureSliderService.GetAllFeatureSlidersAsync();
			return View(values);
		}
    }
}
