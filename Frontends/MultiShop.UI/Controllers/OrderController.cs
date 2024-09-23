using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.OrderDTOs.AddressDTOs;
using MultiShop.UI.Services.Interfaces;
using MultiShop.UI.Services.OrderServices.AddressServices;

namespace MultiShop.UI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAddressService _addressService;

        public OrderController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public IActionResult Index()
        {
            ViewBag.dictionary1 = "Home";
            ViewBag.dictionary2 = "Shop";
            ViewBag.dictionary3 = "Checkout";
            ViewBag.dictionary1Url = "/Default/Index";
            ViewBag.dictionary2Url = "/Default/Index";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateAddressDTO createAddressDTO)
        {
            await _addressService.CreateAddressAsync(createAddressDTO);
            return RedirectToAction("Index", "Payment");
        }
    }
}
