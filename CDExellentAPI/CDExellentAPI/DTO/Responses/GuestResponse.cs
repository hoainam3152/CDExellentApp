using CDExellentAPI.Entities;

namespace CDExellentAPI.DTO.Responses
{
    public class GuestResponse
    {
        public int VisitPlanId { get; set; }
        public int GuestUserId { get; set; }
        public bool? IsAccept { get; set; }
        public string? RejectReason { get; set; }

        public GuestResponse()
        {

        }

        public GuestResponse(Guest guest)
        {
            VisitPlanId = guest.VisitPlanId;
            GuestUserId = guest.GuestUserId;
            IsAccept = guest.IsAccept;
            RejectReason = guest.RejectReason;
        }
    }
}
