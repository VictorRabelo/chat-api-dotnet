using System.ComponentModel.DataAnnotations;

namespace ChatApi.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public byte[] PasswordHash { get; set; } = Array.Empty<byte>();
        [Required]
        public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();

        public ICollection<Chat> Chats { get; set; } = new List<Chat>();
        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
