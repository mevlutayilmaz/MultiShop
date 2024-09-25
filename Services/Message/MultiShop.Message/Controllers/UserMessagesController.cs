using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Message.DTOs;
using MultiShop.Message.Services;

namespace MultiShop.Message.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserMessagesController : ControllerBase
    {
        private readonly IUserMessageService _userMessageService;

        public UserMessagesController(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMessages()
        {
            var values = await _userMessageService.GetAllMessagesAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdMessage(string id)
        {
            var values = await _userMessageService.GetByIdMessageAsync(id);
            return Ok(values);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetInboxMessages(string id)
        {
            var values = await _userMessageService.GetInboxMessagesAsync(id);
            return Ok(values);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetSendboxMessages(string id)
        {
            var values = await _userMessageService.GetSendboxMessagesAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageDTO createMessageDTO)
        {
            await _userMessageService.CreateMessageAsync(createMessageDTO);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMessage(UpdateMessageDTO updateMessageDTO)
        {
            await _userMessageService.UpdateMessageAsync(updateMessageDTO);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(string id)
        {
            await _userMessageService.DeleteMessageAsync(id);
            return Ok();
        }
    }
}
