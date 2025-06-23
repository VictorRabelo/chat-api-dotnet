using ChatApi.DTOs;
using ChatApi.Models;
using ChatApi.Repositories;

namespace ChatApi.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chats;
        private readonly IUserRepository _users;

        public ChatService(IChatRepository chats, IUserRepository users)
        {
            _chats = chats;
            _users = users;
        }

        public async Task<ChatDto> CreateChatAsync(int userId, CreateChatRequest request)
        {
            var participants = new List<User>();
            foreach (var id in request.ParticipantIds.Append(userId))
            {
                var user = await _users.GetByIdAsync(id) ?? throw new KeyNotFoundException($"User {id} not found");
                participants.Add(user);
            }
            var chat = new Chat { Name = request.Name, Participants = participants };
            await _chats.AddAsync(chat);
            await _chats.SaveChangesAsync();
            return new ChatDto { Id = chat.Id, Name = chat.Name };
        }

        public async Task<IEnumerable<ChatDto>> GetChatsForUserAsync(int userId)
        {
            var chats = await _chats.GetChatsForUserAsync(userId);
            return chats.Select(c => new ChatDto { Id = c.Id, Name = c.Name });
        }
    }
}
