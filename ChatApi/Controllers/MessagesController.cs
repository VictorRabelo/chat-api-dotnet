using ChatApi.DTOs;
using ChatApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ChatApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("messages")]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messages;
        public MessagesController(IMessageService messages)
        {
            _messages = messages;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(SendMessageRequest request)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var message = await _messages.SendMessageAsync(userId, request);
            return Ok(message);
        }

        [HttpGet("{chatId}")]
        public async Task<IActionResult> GetMessages(int chatId)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var messages = await _messages.GetMessagesAsync(userId, chatId);
            return Ok(messages);
        }
    }
}
