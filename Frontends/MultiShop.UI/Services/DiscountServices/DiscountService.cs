using MultiShop.DTOLayer.DiscountDTOs;

namespace MultiShop.UI.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;

        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDTO createCouponDTO)
        {
            await _httpClient.PutAsJsonAsync("discounts", createCouponDTO);
        }

        public async Task DeleteDiscountCouponAsync(string id)
        {
            await _httpClient.DeleteAsync($"discounts/{id}");
        }

        public async Task<IList<ResultDiscountCouponDTO>> GetAllDiscountCouponsAsync()
        {
            var responseMessage = await _httpClient.GetAsync("discounts");
            return await responseMessage.Content.ReadFromJsonAsync<IList<ResultDiscountCouponDTO>>();
        }

        public async Task<ResultDiscountCouponDTO> GetDiscountCouponByCodeAsync(string code)
        {
            var responseMessage = await _httpClient.GetAsync($"discounts/GetDiscountCouponByCode?code={code}");
            return await responseMessage.Content.ReadFromJsonAsync<ResultDiscountCouponDTO>();
        }

        public async Task<UpdateDiscountCouponDTO> GetDiscountCouponByIdAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"discounts/id");
            return await responseMessage.Content.ReadFromJsonAsync<UpdateDiscountCouponDTO>();
        }

        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDTO updateCouponDTO)
        {
            await _httpClient.PostAsJsonAsync("discounts", updateCouponDTO);
        }
    }
}
