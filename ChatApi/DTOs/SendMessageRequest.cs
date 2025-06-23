using System.ComponentModel.DataAnnotations;

namespace ChatApi.DTOs
{
    public class SendMessageRequest
    {
        [Required]
        public int ChatId { get; set; }
        [Required]
        public string Content { get; set; } = string.Empty;
    }
}
