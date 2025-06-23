using ChatApi.DTOs;

namespace ChatApi.Services
{
    public interface IChatService
    {
        Task<ChatDto> CreateChatAsync(int userId, CreateChatRequest request);
        Task<IEnumerable<ChatDto>> GetChatsForUserAsync(int userId);
    }
}
