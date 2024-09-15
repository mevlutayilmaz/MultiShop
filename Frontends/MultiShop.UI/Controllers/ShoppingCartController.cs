using Microsoft.AspNetCore.Mvc;

namespace MultiShop.UI.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
