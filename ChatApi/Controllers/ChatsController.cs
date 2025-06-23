using ChatApi.DTOs;
using ChatApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ChatApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("chats")]
    public class ChatsController : ControllerBase
    {
        private readonly IChatService _chats;
        public ChatsController(IChatService chats)
        {
            _chats = chats;
        }

        [HttpPost]
        public async Task<IActionResult> CreateChat(CreateChatRequest request)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var chat = await _chats.CreateChatAsync(userId, request);
            return Ok(chat);
        }

        [HttpGet]
        public async Task<IActionResult> GetChats()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var chats = await _chats.GetChatsForUserAsync(userId);
            return Ok(chats);
        }
    }
}
