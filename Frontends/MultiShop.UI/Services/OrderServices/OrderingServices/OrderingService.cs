using MultiShop.DTOLayer.OrderDTOs.OrderingDTOs;

namespace MultiShop.UI.Services.OrderServices.OrderingServices
{
    public class OrderingService : IOrderingService
    {
        private readonly HttpClient _httpClient;

        public OrderingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultOrderingDTO>> GetOrderingByUserId()
        {
            var responseMessage = await _httpClient.GetAsync("orderings/GetOrderingByUserId");
            return await responseMessage.Content.ReadFromJsonAsync<List<ResultOrderingDTO>>();
        }
    }
}
