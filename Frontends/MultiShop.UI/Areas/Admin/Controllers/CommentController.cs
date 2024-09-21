using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CommentDTOs;
using MultiShop.UI.Services.CommentServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Comment")]
    public class CommentController : Controller
    {
        
        private readonly ICommentService _commentService;

		public CommentController(ICommentService commentService)
		{
			_commentService = commentService;
		}

		[Route("Index")]
        public async Task<IActionResult> Index()
        {
            CommentViewbagList();
            var values = await _commentService.GetAllCommentsAsync();
            return View(values);
        }

        [Route("CreateComment")]
        public IActionResult CreateComment()
        {
            CommentViewbagList();
            return View();
        }

        [HttpPost]
        [Route("CreateComment")]
        public async Task<IActionResult> CreateComment(CreateCommentDTO createCommentDTO)
        {
            await _commentService.CreateCommentAsync(createCommentDTO);
			return RedirectToAction("Index", "Comment", new { area = "Admin" });
		}

        [Route("DeleteComment/{id}")]
        public async Task<IActionResult> DeleteComment(string id)
        {
            await _commentService.DeleteCommentAsync(id);
			return RedirectToAction("Index", "Comment", new { area = "Admin" });
		}

        [Route("UpdateComment/{id}")]
        public async Task<IActionResult> UpdateComment(string id)
        {
            CommentViewbagList();
            var values = await _commentService.GetByIdCommentAsync(id);
			return View(values);
		}

        [Route("UpdateComment/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateComment(UpdateCommentDTO updateCommentDTO)
        {
            await _commentService.UpdateCommentAsync(updateCommentDTO);
			return RedirectToAction("Index", "Comment", new { area = "Admin" });
		}

		void CommentViewbagList()
		{
			ViewBag.h1 = "Home";
			ViewBag.h2 = "Comments";
			ViewBag.h3 = "Comment List";
			ViewBag.h0 = "Comment Operations";
		}
	}
}
