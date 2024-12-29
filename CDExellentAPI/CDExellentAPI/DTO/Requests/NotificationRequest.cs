using System.ComponentModel.DataAnnotations;

namespace CDExellentAPI.DTO.Requests
{
    public class NotificationRequest
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public int CreatorId { get; set; }
    }
}
