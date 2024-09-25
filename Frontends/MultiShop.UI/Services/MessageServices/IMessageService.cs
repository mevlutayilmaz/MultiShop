using MultiShop.DTOLayer.MessageDTOs;

namespace MultiShop.UI.Services.MessageServices
{
    public interface IMessageService
    {
        Task<List<ResultInboxMessageDTO>> GetInboxMessagesAsync();
        Task<List<ResultSendboxMessageDTO>> GetSendboxMessagesAsync();
        Task CreateMessageAsync(CreateMessageDTO createMessageDTO);
    }
}
