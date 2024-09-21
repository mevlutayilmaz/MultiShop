using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CommentDTOs;
using MultiShop.UI.Services.CommentServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.UI.Controllers
{
    [AllowAnonymous]
    [Route("ProductList")]
    public class ProductListController : Controller
    {
        private readonly ICommentService _commentService;

		public ProductListController(ICommentService commentService)
		{
			_commentService = commentService;
		}

		[Route("Index/{categoryId}")]
        public IActionResult Index(string categoryId)
        {
            ViewBag.dictionary1 = "Home";
            ViewBag.dictionary2 = "Products";
            ViewBag.dictionary3 = "Product List";
            ViewBag.dictionary1Url = "/Default/Index";
            ViewBag.dictionary2Url = "/Default/Index";
            ViewBag.categoryId = categoryId;
            return View();
        }

        [Route("ProductDetail/{id}")]
        public async Task<IActionResult> ProductDetail(string id)
        {
            ViewBag.dictionary1 = "Home";
            ViewBag.dictionary2 = "Products";
            ViewBag.dictionary3 = "Product Detail";
            ViewBag.dictionary1Url = "/Default/Index";
            ViewBag.dictionary2Url = "/Default/Index";
            ViewBag.id = id;
            ViewBag.commentCount = await _commentService.CommentCountByProductAsync(id);
            return View();
        }

        public PartialViewResult AddComment(string id)
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDTO createCommentDTO)
        {
            await _commentService.CreateCommentAsync(createCommentDTO);
			return RedirectToAction("Index", "Default");
		}
    }
}
