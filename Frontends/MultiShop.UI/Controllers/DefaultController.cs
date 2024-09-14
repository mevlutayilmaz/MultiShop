using Microsoft.AspNetCore.Mvc;

namespace MultiShop.UI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
