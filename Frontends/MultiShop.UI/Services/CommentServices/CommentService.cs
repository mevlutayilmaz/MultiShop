using MultiShop.DTOLayer.CommentDTOs;

namespace MultiShop.UI.Services.CommentServices
{
	public class CommentService : ICommentService
	{
		private readonly HttpClient _httpClient;
		public CommentService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<int> CommentCountByProductAsync(string productId)
		{
			var responseMessage = await _httpClient.GetAsync($"comments/CommentCountByProduct?productId={productId}");
			return await responseMessage.Content.ReadFromJsonAsync<int>();
		}

		public async Task CreateCommentAsync(CreateCommentDTO createCommentDTO)
		{
			await _httpClient.PostAsJsonAsync("comments", createCommentDTO);
		}

		public async Task DeleteCommentAsync(string id)
		{
			await _httpClient.DeleteAsync($"comments/{id}");
		}

		public async Task<UpdateCommentDTO> GetByIdCommentAsync(string id)
		{
			var responseMessage = await _httpClient.GetAsync($"comments/{id}");
			return await responseMessage.Content.ReadFromJsonAsync<UpdateCommentDTO>();
			
		}

		public async Task<List<ResultCommentDTO>> GetAllCommentsAsync()
		{
			var responseMessage = await _httpClient.GetAsync("comments");
			return await responseMessage.Content.ReadFromJsonAsync<List<ResultCommentDTO>>();
		}

		public async Task<List<ResultCommentDTO>> GetCommentsByProductIdAsync(string categoryId)
		{
			var responseMessage = await _httpClient.GetAsync($"comments/GetCommentByProductId/{categoryId}");
			var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCommentDTO>>();
			return values;
		}

		public async Task UpdateCommentAsync(UpdateCommentDTO updateCommentDTO)
		{
			await _httpClient.PutAsJsonAsync("comments", updateCommentDTO);
		}

        public async Task<double> RatingAverageByProductAsync(string productId)
        {
            var responseMessage = await _httpClient.GetAsync($"comments/RatingAverageByProduct?productId={productId}");
            return await responseMessage.Content.ReadFromJsonAsync<double>();
        }
    }
}
