using ChatApi.Data;
using ChatApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatApi.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly ApplicationDbContext _context;
        public ChatRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Chat chat)
        {
            await _context.Chats.AddAsync(chat);
        }

        public async Task<Chat?> GetByIdAsync(int id)
        {
            return await _context.Chats
                .Include(c => c.Participants)
                .Include(c => c.Messages)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Chat>> GetChatsForUserAsync(int userId)
        {
            return await _context.Chats
                .Include(c => c.Participants)
                .Where(c => c.Participants.Any(u => u.Id == userId))
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
