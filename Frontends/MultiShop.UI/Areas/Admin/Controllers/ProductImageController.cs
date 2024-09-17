using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CatalogDTOs.ProductImageDTOs;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/ProductImage")]
    public class ProductImageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductImageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index/{productId}")]
        public async Task<IActionResult> Index(string productId)
        {
            ViewBag.h0 = "Özel Teklif İşlemleri";
            ViewBag.h1 = "Ana Sayfa";
            ViewBag.h2 = "Özel Teklifler";
            ViewBag.h3 = "Özel Teklif Listesi";
            ViewBag.productId = productId;
            TempData["ProductId"] = productId;

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7200/api/ProductImages/GetProductImageByProductId/" + productId);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductImageDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("CreateProductImage/{productId}")]
        public IActionResult CreateProductImage(string productId)
        {
            ViewBag.h0 = "Özel Teklif İşlemleri";
            ViewBag.h1 = "Ana Sayfa";
            ViewBag.h2 = "Özel Teklifler";
            ViewBag.h3 = "Yeni Özel Teklif Girişi";
            return View();
        }

        [HttpPost]
        [Route("CreateProductImage/{productId}")]
        public async Task<IActionResult> CreateProductImage(string productId, CreateProductImageDTO createProductImageDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductImageDTO);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7200/api/ProductImages", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "ProductImage", new { area = "Admin", productId = productId });
            }
            return View();
        }

        [Route("DeleteProductImage/{id}")]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7200/api/ProductImages/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "ProductImage", new { area = "Admin", productId = TempData["ProductId"]?.ToString() });
            }
            return View();
        }

        [Route("UpdateProductImage/{id}")]
        public async Task<IActionResult> UpdateProductImage(string id)
        {
            ViewBag.h0 = "Özel Teklif İşlemleri";
            ViewBag.h1 = "Ana Sayfa";
            ViewBag.h2 = "Özel Teklifler";
            ViewBag.h3 = "Özel Teklif Güncelleme";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7200/api/ProductImages/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductImageDTO>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("UpdateProductImage/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDTO updateProductImageDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductImageDTO);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7200/api/ProductImages", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "ProductImage", new { area = "Admin", productId = updateProductImageDTO.ProductId });
            }
            return View();
        }
    }
}
