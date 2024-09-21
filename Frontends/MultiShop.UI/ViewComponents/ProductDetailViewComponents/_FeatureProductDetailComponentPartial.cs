using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CatalogDTOs.ProductDTOs;
using MultiShop.UI.Services.CatalogServices.ProductServices;
using MultiShop.UI.Services.CommentServices;
using Newtonsoft.Json;

namespace MultiShop.UI.ViewComponents.ProductDetailViewComponents
{
    public class _FeatureProductDetailComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;
        private readonly ICommentService _commentService;

        public _FeatureProductDetailComponentPartial(IProductService productService, ICommentService commentService)
        {
            _productService = productService;
            _commentService = commentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            ViewBag.commentCount = await _commentService.CommentCountByProductAsync(id);
            ViewBag.averageRating = await _commentService.RatingAverageByProductAsync(id);
            var values = await _productService.GetByIdProductAsync(id);
            return View(values);
        }
    }
}
