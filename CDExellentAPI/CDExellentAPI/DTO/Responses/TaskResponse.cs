using CDExellentAPI.Entities;

namespace CDExellentAPI.DTO.Responses
{
    public class TaskResponse
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int AssigneeId { get; set; }
        public int ReporterId { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PlanUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int TaskStatusId { get; set; }
        public int VisitPlanId { get; set; }

        public TaskResponse()
        {

        }

        public TaskResponse(Entities.Task task)
        {
            ID = task.ID;
            Title = task.Title;
            AssigneeId = task.AssigneeId;
            ReporterId = task.ReporterId;
            Description = task.Description;
            StartDate = task.StartDate;
            EndDate = task.EndDate;
            PlanUserId = task.PlanUserId;
            CreatedDate = task.CreatedDate;
            TaskStatusId = task.TaskStatusId;
            VisitPlanId = task.VisitPlanId;
        }
    }
}
