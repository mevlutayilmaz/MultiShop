using MultiShop.DTOLayer.MessageDTOs;

namespace MultiShop.UI.Services.MessageServices
{
    public class MessageService : IMessageService
    {
        private readonly HttpClient _httpClient;

        public MessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateMessageAsync(CreateMessageDTO createMessageDTO)
        {
            await _httpClient.PostAsJsonAsync("usermessages", createMessageDTO);
        }

        public async Task<List<ResultInboxMessageDTO>> GetInboxMessagesAsync()
        {
            var responseMessage = await _httpClient.GetAsync("usermessages/GetInboxMessages");
            return await responseMessage.Content.ReadFromJsonAsync<List<ResultInboxMessageDTO>>();
        }

        public async Task<List<ResultSendboxMessageDTO>> GetSendboxMessagesAsync()
        {
            var responseMessage = await _httpClient.GetAsync("usermessages/GetSendboxMessages");
            return await responseMessage.Content.ReadFromJsonAsync<List<ResultSendboxMessageDTO>>();
        }
    }
}
