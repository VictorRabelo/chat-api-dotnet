using ChatApi.DTOs;

namespace ChatApi.Services
{
    public interface IMessageService
    {
        Task<MessageDto> SendMessageAsync(int userId, SendMessageRequest request);
        Task<IEnumerable<MessageDto>> GetMessagesAsync(int userId, int chatId);
    }
}
