using Microsoft.AspNetCore.Mvc;
using MultiShop.UI.Services.BasketServices;
using MultiShop.UI.Services.CatalogServices.ProductServices;

namespace MultiShop.UI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly IProductService _productService;

        public ShoppingCartController(IBasketService basketService, IProductService productService)
        {
            _basketService = basketService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            ViewBag.dictionary1 = "Home";
            ViewBag.dictionary2 = "Shop";
            ViewBag.dictionary3 = "Shopping Cart";
            ViewBag.dictionary1Url = "/Default/Index";
            ViewBag.dictionary2Url = "#";
            return View();
        }

        public async Task<IActionResult> AddBasketItem(string id)
        { 
            var product = await _productService.GetByIdProductAsync(id);
            await _basketService.AddBasketItemAsync(new()
            {
                ProductId = product.Id,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                ProductName = product.Name,
                Quantity = 1
            });
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveBasketItem(string id)
        {
            await _basketService.RemoveBasketItemAsync(id);
            return RedirectToAction("Index");
        }
    }
}
