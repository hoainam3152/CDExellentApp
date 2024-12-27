using System.ComponentModel.DataAnnotations;

namespace CDExellentAPI.DTO.Requests
{
    public class VisitPlanRequest
    {
        [Required]
        public DateTime PlanDate { get; set; }
        [Required]
        public int TypeDateId { get; set; }
        [Required]
        public int DistributorId { get; set; }
        [Required]
        public string Purpose { get; set; }
        [Required]
        public int PlanUserId { get; set; }
        [Required]
        public int PlanStatusId { get; set; }
    }
}
