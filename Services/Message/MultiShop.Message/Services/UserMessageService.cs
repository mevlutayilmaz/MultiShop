using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiShop.Message.DAL.Contexts;
using MultiShop.Message.DAL.Entities;
using MultiShop.Message.DTOs;

namespace MultiShop.Message.Services
{
    public class UserMessageService : IUserMessageService
    {
        private readonly MessageContext _context;
        private readonly IMapper _mapper;

        public UserMessageService(MessageContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateMessageAsync(CreateMessageDTO createMessageDTO)
        {
            await _context.UserMessages.AddAsync(_mapper.Map<UserMessage>(createMessageDTO));
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMessageAsync(string id)
        {
            var value = await _context.UserMessages.FindAsync(Guid.Parse(id));
            _context.UserMessages.Remove(value);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ResultMessageDTO>> GetAllMessagesAsync()
        {
            var values = await _context.UserMessages.ToListAsync();
            return _mapper.Map<List<ResultMessageDTO>>(values);
        }

        public async Task<GetByIdMessageDTO> GetByIdMessageAsync(string id)
        {
            var value = await _context.UserMessages.FindAsync(Guid.Parse(id));
            return _mapper.Map<GetByIdMessageDTO>(value);
        }

        public async Task<List<ResultInboxMessageDTO>> GetInboxMessagesAsync(string id)
        {
            var values = await _context.UserMessages.Where(m => m.ReceiverId == id).ToListAsync();
            return _mapper.Map<List<ResultInboxMessageDTO>>(values);
        }

        public async Task<List<ResultSendboxMessageDTO>> GetSendboxMessagesAsync(string id)
        {
            var values = await _context.UserMessages.Where(m => m.SenderId == id).ToListAsync();
            return _mapper.Map<List<ResultSendboxMessageDTO>>(values);
        }

        public async Task UpdateMessageAsync(UpdateMessageDTO updateMessageDTO)
        {
            _context.UserMessages.Update(_mapper.Map<UserMessage>(updateMessageDTO));
            await _context.SaveChangesAsync();
        }
    }
}
