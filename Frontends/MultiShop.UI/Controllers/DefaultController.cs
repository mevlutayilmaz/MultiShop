using Microsoft.AspNetCore.Mvc;

namespace MultiShop.UI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.dictionary1 = "MultiShop";
            ViewBag.dictionary2 = "Home";
            ViewBag.dictionary3 = "Products";
            ViewBag.dictionary1Url = "/Default/Index";
            ViewBag.dictionary2Url = "/Default/Index";
            return View();
        }
    }
}
