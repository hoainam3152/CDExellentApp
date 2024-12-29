using CDExellentAPI.Entities;

namespace CDExellentAPI.DTO.Requests
{
    public class GuestRequest
    {
        public int VisitPlanId { get; set; }
        public int GuestUserId { get; set; }
    }
}
