using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CatalogDTOs.BrandDTOs;
using MultiShop.UI.Services.CatalogServices.BrandServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Brand")]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;
		public BrandController(IBrandService brandService)
		{
			_brandService = brandService;
		}

		[Route("Index")]
        public async Task<IActionResult> Index()
        {
            BrandViewbagList();

            var values = await _brandService.GetAllBrandsAsync();
            return View(values);
        }

        [Route("CreateBrand")]
        public IActionResult CreateBrand()
        {
            BrandViewbagList();
            return View();
        }

        [HttpPost]
        [Route("CreateBrand")]
        public async Task<IActionResult> CreateBrand(CreateBrandDTO createBrandDTO)
        {
            await _brandService.CreateBrandAsync(createBrandDTO);
			return RedirectToAction("Index", "Brand", new { area = "Admin" });
        }

        [Route("DeleteBrand/{id}")]
        public async Task<IActionResult> DeleteBrand(string id)
        {
            await _brandService.DeleteBrandAsync(id);
			return RedirectToAction("Index", "Brand", new { area = "Admin" });
		}

        [Route("UpdateBrand/{id}")]
        public async Task<IActionResult> UpdateBrand(string id)
        {
            BrandViewbagList();
            var values = await _brandService.GetByIdBrandAsync(id);
			return View(values);
        }

        [Route("UpdateBrand/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDTO updateBrandDTO)
        {
            await _brandService.UpdateBrandAsync(updateBrandDTO);
			return RedirectToAction("Index", "Brand", new { area = "Admin" });
		}

		void BrandViewbagList()
		{
			ViewBag.h1 = "Home";
			ViewBag.h2 = "Brands";
			ViewBag.h3 = "Brand List";
			ViewBag.h0 = "Brand Operations";
		}
	}
}
