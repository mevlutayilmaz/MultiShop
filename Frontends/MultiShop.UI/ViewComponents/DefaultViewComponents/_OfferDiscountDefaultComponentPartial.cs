using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CatalogDTOs.OfferDiscountDTOs;
using MultiShop.UI.Services.CatalogServices.OfferDiscountServices;
using Newtonsoft.Json;

namespace MultiShop.UI.ViewComponents.DefaultViewComponents
{
    public class _OfferDiscountDefaultComponentPartial : ViewComponent
    {
        private readonly IOfferDiscountService _offerDiscountService;

		public _OfferDiscountDefaultComponentPartial(IOfferDiscountService offerDiscountService)
		{
			_offerDiscountService = offerDiscountService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _offerDiscountService.GetAllOfferDiscountsAsync();
            return View(values);
        }
    }
}
