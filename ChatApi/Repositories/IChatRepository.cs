using ChatApi.Models;

namespace ChatApi.Repositories
{
    public interface IChatRepository
    {
        Task<Chat?> GetByIdAsync(int id);
        Task<IEnumerable<Chat>> GetChatsForUserAsync(int userId);
        Task AddAsync(Chat chat);
        Task SaveChangesAsync();
    }
}
