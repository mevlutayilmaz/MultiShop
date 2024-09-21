using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CommentDTOs;
using MultiShop.UI.Services.CommentServices;
using Newtonsoft.Json;

namespace MultiShop.UI.ViewComponents.ProductDetailViewComponents
{
    public class _ReviewsProductDetailComponentPartial : ViewComponent
    {
        private readonly ICommentService _commentService;

		public _ReviewsProductDetailComponentPartial(ICommentService commentService)
		{
			_commentService = commentService;
		}

		public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _commentService.GetCommentsByProductIdAsync(id);
            return View(values);
        }
    }
}
