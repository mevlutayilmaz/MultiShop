using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CatalogDTOs.FeatureSliderDTOs;
using MultiShop.UI.Services.CatalogServices.FeatureSliderServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/FeatureSlider")]
    public class FeatureSliderController : Controller
    {
        private readonly IFeatureSliderService _featureSliderService;

		public FeatureSliderController(IFeatureSliderService featureSliderService)
		{
			_featureSliderService = featureSliderService;
		}

		[Route("Index")]
        public async Task<IActionResult> Index()
        {
            FeatureSliderViewbagList();
            var values = await _featureSliderService.GetAllFeatureSlidersAsync();
            return View(values);
        }

        [Route("CreateFeatureSlider")]
        public IActionResult CreateFeatureSlider()
        {
            FeatureSliderViewbagList();
            return View();
        }

        [HttpPost]
        [Route("CreateFeatureSlider")]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDTO createFeatureSliderDTO)
        {
            await _featureSliderService.CreateFeatureSliderAsync(createFeatureSliderDTO);
			return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
		}

        [Route("DeleteFeatureSlider/{id}")]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            await _featureSliderService.DeleteFeatureSliderAsync(id);
			return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
		}

        [Route("UpdateFeatureSlider/{id}")]
        public async Task<IActionResult> UpdateFeatureSlider(string id)
        {
            FeatureSliderViewbagList();
            var values = await _featureSliderService.GetByIdFeatureSliderAsync(id);
            return View(values);
        }

        [Route("UpdateFeatureSlider/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDTO updateFeatureSliderDTO)
        {
            await _featureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDTO);
			return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
		}

		void FeatureSliderViewbagList()
		{
			ViewBag.h1 = "Home";
			ViewBag.h2 = "Feature Sliders";
			ViewBag.h3 = "Feature Slider List";
			ViewBag.h0 = "Feature Slider Operations";
		}
	}
}
