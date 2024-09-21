using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CatalogDTOs.OfferDiscountDTOs;
using MultiShop.UI.Services.CatalogServices.OfferDiscountServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/OfferDiscount")]
    public class OfferDiscountController : Controller
    {
        private readonly IOfferDiscountService _offerDiscountService;

		public OfferDiscountController(IOfferDiscountService offerDiscountService)
		{
			_offerDiscountService = offerDiscountService;
		}

		[Route("Index")]
        public async Task<IActionResult> Index()
        {
            OfferDiscountViewbagList();
            var values = await _offerDiscountService.GetAllOfferDiscountsAsync();
            return View(values);
        }

        [Route("CreateOfferDiscount")]
        public IActionResult CreateOfferDiscount()
        {
            OfferDiscountViewbagList();
            return View();
        }

        [HttpPost]
        [Route("CreateOfferDiscount")]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDTO createOfferDiscountDTO)
        {
            await _offerDiscountService.CreateOfferDiscountAsync(createOfferDiscountDTO);
			return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
		}

        [Route("DeleteOfferDiscount/{id}")]
        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            await _offerDiscountService.DeleteOfferDiscountAsync(id);
			return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
		}

        [Route("UpdateOfferDiscount/{id}")]
        public async Task<IActionResult> UpdateOfferDiscount(string id)
        {
            OfferDiscountViewbagList();
            var values = await _offerDiscountService.GetByIdOfferDiscountAsync(id);
			return View(values);
		}

        [Route("UpdateOfferDiscount/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDTO updateOfferDiscountDTO)
        {
            await _offerDiscountService.UpdateOfferDiscountAsync(updateOfferDiscountDTO);
			return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
		}

		void OfferDiscountViewbagList()
		{
			ViewBag.h1 = "Home";
			ViewBag.h2 = "Offer Discounts";
			ViewBag.h3 = "Offer Discount List";
			ViewBag.h0 = "Offer Discount Operations";
		}
	}
}
