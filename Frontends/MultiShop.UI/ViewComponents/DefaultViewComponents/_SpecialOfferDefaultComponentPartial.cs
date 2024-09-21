using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CatalogDTOs.SpecialOfferDTOs;
using MultiShop.UI.Services.CatalogServices.SpecialOfferServices;
using Newtonsoft.Json;

namespace MultiShop.UI.ViewComponents.DefaultViewComponents
{
    public class _SpecialOfferDefaultComponentPartial : ViewComponent
    {
        private readonly ISpecialOfferService _specialOfferService;

		public _SpecialOfferDefaultComponentPartial(ISpecialOfferService specialOfferService)
		{
			_specialOfferService = specialOfferService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _specialOfferService.GetAllSpecialOffersAsync();
            return View(values);
        }
    }
}
