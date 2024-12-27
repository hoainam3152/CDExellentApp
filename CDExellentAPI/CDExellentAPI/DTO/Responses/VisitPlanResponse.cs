using CDExellentAPI.Entities;

namespace CDExellentAPI.DTO.Responses
{
    public class VisitPlanResponse
    {
        public int ID { get; set; }
        public DateTime PlanDate { get; set; }
        public int TypeDateId { get; set; }
        public int DistributorId { get; set; }
        public string Purpose { get; set; }
        public int PlanUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int PlanStatusId { get; set; }

        public VisitPlanResponse()
        {

        }

        public VisitPlanResponse(VisitPlan visitPlan)
        {
            ID = visitPlan.ID;
            PlanDate = visitPlan.PlanDate;
            TypeDateId = visitPlan.TypeDateId;
            DistributorId = visitPlan.DistributorId;
            Purpose = visitPlan.Purpose;
            PlanUserId = visitPlan.PlanUserId;
            CreatedDate = visitPlan.CreatedDate;
            PlanStatusId = visitPlan.PlanStatusId;
        }
    }
}
