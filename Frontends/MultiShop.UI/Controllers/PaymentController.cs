using Microsoft.AspNetCore.Mvc;

namespace MultiShop.UI.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.dictionary1 = "Home";
            ViewBag.dictionary2 = "Shop";
            ViewBag.dictionary3 = "Payment";
            ViewBag.dictionary1Url = "/Default/Index";
            ViewBag.dictionary2Url = "/Default/Index";
            return View();
        }
    }
}
