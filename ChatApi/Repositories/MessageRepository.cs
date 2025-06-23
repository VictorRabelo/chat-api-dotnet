using ChatApi.Data;
using ChatApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatApi.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationDbContext _context;
        public MessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Message message)
        {
            await _context.Messages.AddAsync(message);
        }

        public async Task<IEnumerable<Message>> GetMessagesAsync(int chatId)
        {
            return await _context.Messages
                .Where(m => m.ChatId == chatId)
                .Include(m => m.Sender)
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
