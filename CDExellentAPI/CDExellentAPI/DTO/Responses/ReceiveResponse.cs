using CDExellentAPI.Entities;

namespace CDExellentAPI.DTO.Responses
{
    public class ReceiveResponse
    {
        public int NotificationId { get; set; }
        public int ReceiverId { get; set; }
        public bool? IsSeen { get; set; }

        public ReceiveResponse()
        {

        }

        public ReceiveResponse(Receive receive)
        {
            NotificationId = receive.NotificationId;
            ReceiverId = receive.ReceiverId;
            IsSeen = receive.IsSeen;
        }
    }
}
