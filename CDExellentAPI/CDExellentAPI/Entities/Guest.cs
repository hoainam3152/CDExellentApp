using System.ComponentModel.DataAnnotations.Schema;

namespace CDExellentAPI.Entities
{
    [Table("Guest")]
    public class Guest
    {
        public int VisitPlanId { get; set; }
        public int GuestUserId { get; set; }
        public bool? IsAccept { get; set; }
        public string? RejectReason { get; set; }

        public VisitPlan VisitPlan { get; set; }
        public User GuestUser { get; set; }
    }
}
