using System.ComponentModel.DataAnnotations;

namespace ChatApi.Models
{
    public class Chat
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public ICollection<User> Participants { get; set; } = new List<User>();
        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
