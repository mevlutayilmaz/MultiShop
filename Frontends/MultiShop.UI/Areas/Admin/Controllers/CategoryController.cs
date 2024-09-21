using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CatalogDTOs.CategoryDTOs;
using MultiShop.UI.Services.CatalogServices.CategoryServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Category")]
    public class CategoryController : Controller
    {
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly ICategoryService _categoryService;
		public CategoryController(IHttpClientFactory httpClientFactory, ICategoryService categoryService)
		{
			_httpClientFactory = httpClientFactory;
			_categoryService = categoryService;
		}

		[Route("Index")]
		public async Task<IActionResult> Index()
		{
			CategoryViewbagList();
			var values = await _categoryService.GetAllCategoryAsync();
			return View(values);
		}

		[HttpGet]
		[Route("CreateCategory")]
		public IActionResult CreateCategory()
		{
			CategoryViewbagList();
			return View();
		}

		[HttpPost]
		[Route("CreateCategory")]
		public async Task<IActionResult> CreateCategory(CreateCategoryDTO createCategoryDTO)
		{
			await _categoryService.CreateCategoryAsync(createCategoryDTO);
			return RedirectToAction("Index", "Category", new { area = "Admin" });
		}

		[Route("DeleteCategory/{id}")]
		public async Task<IActionResult> DeleteCategory(string id)
		{
			await _categoryService.DeleteCategoryAsync(id);
			return RedirectToAction("Index", "Category", new { area = "Admin" });
		}

		[Route("UpdateCategory/{id}")]
		[HttpGet]
		public async Task<IActionResult> UpdateCategory(string id)
		{
			CategoryViewbagList();
			var values = await _categoryService.GetByIdCategoryAsync(id);
			return View(values);
		}
		[Route("UpdateCategory/{id}")]
		[HttpPost]
		public async Task<IActionResult> UpdateCategory(UpdateCategoryDTO updateCategoryDTO)
		{
			await _categoryService.UpdateCategoryAsync(updateCategoryDTO);
			return RedirectToAction("Index", "Category", new { area = "Admin" });
		}

		void CategoryViewbagList()
		{
			ViewBag.h1 = "Home";
			ViewBag.h2 = "Categories";
			ViewBag.h3 = "Category List";
			ViewBag.h0 = "Category Operations";
		}
	}
}
