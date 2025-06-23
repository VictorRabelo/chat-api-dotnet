using ChatApi.DTOs;
using ChatApi.Models;
using ChatApi.Repositories;

namespace ChatApi.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messages;
        private readonly IChatRepository _chats;
        private readonly IUserRepository _users;

        public MessageService(IMessageRepository messages, IChatRepository chats, IUserRepository users)
        {
            _messages = messages;
            _chats = chats;
            _users = users;
        }

        public async Task<MessageDto> SendMessageAsync(int userId, SendMessageRequest request)
        {
            var chat = await _chats.GetByIdAsync(request.ChatId) ?? throw new KeyNotFoundException("Chat not found");
            if (!chat.Participants.Any(p => p.Id == userId))
                throw new UnauthorizedAccessException("User not in chat");

            var message = new Message
            {
                ChatId = chat.Id,
                SenderId = userId,
                Content = request.Content,
                SentAt = DateTime.UtcNow
            };
            await _messages.AddAsync(message);
            await _messages.SaveChangesAsync();
            return new MessageDto
            {
                Id = message.Id,
                SenderId = message.SenderId,
                Content = message.Content,
                SentAt = message.SentAt
            };
        }

        public async Task<IEnumerable<MessageDto>> GetMessagesAsync(int userId, int chatId)
        {
            var chat = await _chats.GetByIdAsync(chatId) ?? throw new KeyNotFoundException("Chat not found");
            if (!chat.Participants.Any(p => p.Id == userId))
                throw new UnauthorizedAccessException("User not in chat");

            var messages = await _messages.GetMessagesAsync(chatId);
            return messages.Select(m => new MessageDto
            {
                Id = m.Id,
                SenderId = m.SenderId,
                Content = m.Content,
                SentAt = m.SentAt
            });
        }
    }
}
