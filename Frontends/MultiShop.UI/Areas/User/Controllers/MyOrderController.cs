using Microsoft.AspNetCore.Mvc;
using MultiShop.UI.Services.OrderServices.OrderingServices;

namespace MultiShop.UI.Areas.User.Controllers
{
    [Area("User")]
    public class MyOrderController : Controller
    {
        private readonly IOrderingService _orderingService;

        public MyOrderController(IOrderingService orderingService)
        {
            _orderingService = orderingService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _orderingService.GetOrderingByUserId();
            return View(values);
        }
    }
}
