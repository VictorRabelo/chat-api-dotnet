using System.ComponentModel.DataAnnotations;

namespace ChatApi.DTOs
{
    public class CreateChatRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public List<int> ParticipantIds { get; set; } = new();
    }
}
