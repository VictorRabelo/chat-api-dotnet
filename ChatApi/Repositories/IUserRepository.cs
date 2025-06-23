using ChatApi.Models;

namespace ChatApi.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByUsernameAsync(string username);
        Task<User?> GetByIdAsync(int id);
        Task AddAsync(User user);
        Task<IEnumerable<User>> GetAllAsync();
        Task SaveChangesAsync();
    }
}
