using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Contexts;
using MultiShop.Comment.DTOs;

namespace MultiShop.Comment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _context;

        public CommentsController(CommentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            var value = await _context.UserComments.ToListAsync();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById(string id)
        {
            var value = await _context.UserComments.FindAsync(Guid.Parse(id));
            return Ok(value);
        }

        [HttpGet("[action]/{productId}")]
        public async Task<IActionResult> GetCommentByProductId(string productId)
        {
            var value = await _context.UserComments.Where(c => c.ProductId == productId).ToListAsync();
            return Ok(value);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> CommentCountByProduct(string productId)
        {
            var value = await _context.UserComments.CountAsync(c => c.ProductId == productId);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentDTO createCommentDTO)
        {
            await _context.UserComments.AddAsync(new()
            {
                CommentDetail = createCommentDTO.CommentDetail,
                CreatedDate = DateTime.Now,
                ImageUrl = createCommentDTO.ImageUrl,
                NameSurname = createCommentDTO.NameSurname,
                Rating = createCommentDTO.Rating,
                Status = true,
                ProductId = createCommentDTO.ProductId
            });
            await _context.SaveChangesAsync();
            return Ok("Yorum ekleme başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComment(UpdateCommentDTO updateCommentDTO)
        {
            _context.UserComments.Update(new()
            {
                Id = Guid.Parse(updateCommentDTO.Id),
                CommentDetail = updateCommentDTO.CommentDetail,
                ImageUrl = updateCommentDTO.ImageUrl,
                CreatedDate = updateCommentDTO.CreatedDate,
                NameSurname = updateCommentDTO.NameSurname,
                Rating = updateCommentDTO.Rating,
                ProductId = updateCommentDTO.ProductId,
                Status = updateCommentDTO.Status,
            });
            await _context.SaveChangesAsync();
            return Ok("Yorum güncelleme başarılı");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(string id)
        {
            var value = await _context.UserComments.FindAsync(Guid.Parse(id));
            _context.UserComments.Remove(value);
            await _context.SaveChangesAsync();
            return Ok("Yorum silme başarılı");
        }
    }
}
