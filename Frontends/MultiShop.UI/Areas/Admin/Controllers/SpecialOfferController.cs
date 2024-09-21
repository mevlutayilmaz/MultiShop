using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CatalogDTOs.SpecialOfferDTOs;
using MultiShop.UI.Services.CatalogServices.ProductImageServices;
using MultiShop.UI.Services.CatalogServices.SpecialOfferServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/SpecialOffer")]
    public class SpecialOfferController : Controller
    {
        private readonly ISpecialOfferService _specialOfferService;

		public SpecialOfferController(ISpecialOfferService specialOfferService)
		{
			_specialOfferService = specialOfferService;
		}

		[Route("Index")]
        public async Task<IActionResult> Index()
        {
			SpecialOfferViewbagList();
            var values = await _specialOfferService.GetAllSpecialOffersAsync();
            return View(values);
        }

        [Route("CreateSpecialOffer")]
        public IActionResult CreateSpecialOffer()
        {
			SpecialOfferViewbagList();
			return View();
        }

        [HttpPost]
        [Route("CreateSpecialOffer")]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDTO createSpecialOfferDTO)
        {
            await _specialOfferService.CreateSpecialOfferAsync(createSpecialOfferDTO);
			return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
		}

        [Route("DeleteSpecialOffer/{id}")]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            await _specialOfferService.DeleteSpecialOfferAsync(id);
			return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
		}

        [Route("UpdateSpecialOffer/{id}")]
        public async Task<IActionResult> UpdateSpecialOffer(string id)
        {
			SpecialOfferViewbagList();
            var values = await _specialOfferService.GetByIdSpecialOfferAsync(id);
			return View(values);
		}

		[Route("UpdateSpecialOffer/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDTO updateSpecialOfferDTO)
        {
            await _specialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDTO);
			return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
		}

		void SpecialOfferViewbagList()
		{
			ViewBag.h1 = "Home";
			ViewBag.h2 = "Special Offers";
			ViewBag.h3 = "Special Offer List";
			ViewBag.h0 = "Special Offer Operations";
		}
	}
}
