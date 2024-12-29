using System.ComponentModel.DataAnnotations;

namespace CDExellentAPI.DTO.Requests
{
    public class ReceiveRequest
    {
        [Required]
        public int NotificationId { get; set; }
        [Required]
        public int ReceiverId { get; set; }
    }
}
