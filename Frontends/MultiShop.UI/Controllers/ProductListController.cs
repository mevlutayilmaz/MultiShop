using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MultiShop.UI.Controllers
{
    [AllowAnonymous]
    [Route("ProductList")]
    public class ProductListController : Controller
    {
        [Route("Index/{categoryId}")]
        public IActionResult Index(string categoryId)
        {
            ViewBag.categoryId = categoryId;
            return View();
        }

        [Route("ProductDetail/{id}")]
        public IActionResult ProductDetail(string id)
        {
            ViewBag.id = id;
            return View();
        }
    }
}
