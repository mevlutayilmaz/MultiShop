using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CatalogDTOs.CategoryDTOs;
using MultiShop.UI.Services.CatalogServices.CategoryServices;
using Newtonsoft.Json;

namespace MultiShop.UI.ViewComponents.DefaultViewComponents
{
    public class _CategoriesDefaultComponentPartial: ViewComponent
    {
        private readonly ICategoryService _categoryService;

		public _CategoriesDefaultComponentPartial(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _categoryService.GetAllCategoryAsync();
            return View(values);
        }
    }
}
