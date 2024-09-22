using MultiShop.DTOLayer.BasketDTOs;

namespace MultiShop.UI.Services.BasketServices
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;
        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task AddBasketItemAsync(BasketItemDTO basketItemDTO)
        {
            await _httpClient.PostAsJsonAsync("baskets/AddBasketItem", basketItemDTO);
        }

        public async Task<BasketTotalDTO> GetBasketAsync()
        {
            var responseMessage = await _httpClient.GetAsync("baskets");
            return await responseMessage.Content.ReadFromJsonAsync<BasketTotalDTO>();
        }

        public async Task RemoveBasketItemAsync(string productId)
        {
            await _httpClient.DeleteAsync($"baskets/RemoveBasketItem/{productId}");
        }
    }
}
