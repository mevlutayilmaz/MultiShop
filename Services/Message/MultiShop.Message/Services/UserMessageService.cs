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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserMessageService(MessageContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateMessageAsync(CreateMessageDTO createMessageDTO)
        {
            var value = _mapper.Map<UserMessage>(createMessageDTO);
            value.IsRead = false;
            value.MessageDate = DateTime.UtcNow;
            await _context.UserMessages.AddAsync(value);
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

        public async Task<List<ResultInboxMessageDTO>> GetInboxMessagesAsync()
        {
            var id = _httpContextAccessor.HttpContext.User.FindFirst("sub").Value;
            var values = await _context.UserMessages.Where(m => m.ReceiverId == id).ToListAsync();
            return _mapper.Map<List<ResultInboxMessageDTO>>(values);
        }

        public async Task<List<ResultSendboxMessageDTO>> GetSendboxMessagesAsync()
        {
            var id = _httpContextAccessor.HttpContext.User.FindFirst("sub").Value;
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
