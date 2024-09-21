using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CatalogDTOs.ContactDTOs;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.UI.Controllers
{
    [AllowAnonymous]
    [Route("Contact")]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            ViewBag.dictionary1 = "MultiShop";
            ViewBag.dictionary2 = "Home";
            ViewBag.dictionary3 = "Contact";
            ViewBag.dictionary1Url = "/Default/Index";
            ViewBag.dictionary2Url = "/Default/Index";
            return View();
        }

        [HttpPost]
        [Route("Index")]
        public async Task<IActionResult> Index(CreateContactDTO createContactDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createContactDTO);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7200/api/Contacts", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
