using System.ComponentModel.DataAnnotations;

namespace ChatApi.Models
{
    public class Message
    {
        public int Id { get; set; }
        [Required]
        public int ChatId { get; set; }
        public Chat? Chat { get; set; }
        [Required]
        public int SenderId { get; set; }
        public User? Sender { get; set; }
        [Required]
        public string Content { get; set; } = string.Empty;
        public DateTime SentAt { get; set; } = DateTime.UtcNow;
    }
}
