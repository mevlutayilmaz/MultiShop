using MultiShop.DTOLayer.CommentDTOs;

namespace MultiShop.UI.Services.CommentServices
{
	public interface ICommentService
	{
		Task<List<ResultCommentDTO>> GetAllCommentsAsync();
		Task CreateCommentAsync(CreateCommentDTO createCommentDTO);
		Task UpdateCommentAsync(UpdateCommentDTO updateCommentDTO);
		Task DeleteCommentAsync(string id);
		Task<UpdateCommentDTO> GetByIdCommentAsync(string id);
		Task<List<ResultCommentDTO>> GetCommentsByProductIdAsync(string categoryId);
		Task<int> CommentCountByProductAsync(string productId);
		Task<double> RatingAverageByProductAsync(string productId);

	}
}
