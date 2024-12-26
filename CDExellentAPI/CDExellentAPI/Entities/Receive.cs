namespace CDExellentAPI.Entities
{
    public class Receive
    {
        public int NotificationId { get; set; }
        public int ReceiverId { get; set; }
        public bool? IsSeen { get; set; }

        public Notification Notification { get; set; }
        public User Receiver { get; set; }
    }
}
