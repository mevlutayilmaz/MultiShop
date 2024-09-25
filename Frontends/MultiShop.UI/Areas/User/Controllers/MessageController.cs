using Microsoft.AspNetCore.Mvc;
using MultiShop.UI.Services.MessageServices;

namespace MultiShop.UI.Areas.User.Controllers
{
    [Area("User")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task<IActionResult> Inbox()
        {
            var values = await _messageService.GetInboxMessagesAsync();
            return View(values);
        }

        public async Task<IActionResult> Sendbox()
        {
            var values = await _messageService.GetSendboxMessagesAsync();
            return View(values);
        }
    }
}
