using ChatApi.Models;

namespace ChatApi.Repositories
{
    public interface IMessageRepository
    {
        Task AddAsync(Message message);
        Task<IEnumerable<Message>> GetMessagesAsync(int chatId);
        Task SaveChangesAsync();
    }
}
