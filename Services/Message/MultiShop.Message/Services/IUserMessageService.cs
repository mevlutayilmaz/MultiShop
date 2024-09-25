using MultiShop.Message.DTOs;

namespace MultiShop.Message.Services
{
    public interface IUserMessageService
    {
        Task<List<ResultMessageDTO>> GetAllMessagesAsync();
        Task<List<ResultInboxMessageDTO>> GetInboxMessagesAsync();
        Task<List<ResultSendboxMessageDTO>> GetSendboxMessagesAsync();
        Task<GetByIdMessageDTO> GetByIdMessageAsync(string id);
        Task CreateMessageAsync(CreateMessageDTO createMessageDTO);
        Task UpdateMessageAsync(UpdateMessageDTO updateMessageDTO);
        Task DeleteMessageAsync(string id);

    }
}
