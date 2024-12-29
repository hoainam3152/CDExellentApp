using CDExellentAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace CDExellentAPI.DTO.Responses
{
    public class NotificationResponse
    {
        public int ID { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        public string Content { get; set; }
        public int CreatorId { get; set; }
        public DateTime CreatedDate { get; set; }

        public NotificationResponse()
        {

        }

        public NotificationResponse(Notification notification)
        {
            ID = notification.ID;
            Title = notification.Title;
            Content = notification.Content;
            CreatorId = notification.CreatorId;
            CreatedDate = notification.CreatedDate;
        }
    }
}
