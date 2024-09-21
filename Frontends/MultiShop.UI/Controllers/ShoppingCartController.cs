using Microsoft.AspNetCore.Mvc;

namespace MultiShop.UI.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.dictionary1 = "Home";
            ViewBag.dictionary2 = "Shop";
            ViewBag.dictionary3 = "Shopping Cart";
            ViewBag.dictionary1Url = "/Default/Index";
            ViewBag.dictionary2Url = "#";
            return View();
        }
    }
}
