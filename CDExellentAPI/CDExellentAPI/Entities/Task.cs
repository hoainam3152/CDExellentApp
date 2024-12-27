using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CDExellentAPI.Entities
{
    [Table("Task")]
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        public int AssigneeId { get; set; }
        public int ReporterId { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PlanUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        [StringLength(255)]
        public string? ReporterFileName { get; set; }
        [StringLength(255)]
        public string? AssigneeFileName { get; set; }
        public int TaskStatusId { get; set; }
        public int? StarRate { get; set; }
        [StringLength(255)]
        public string? Comment { get; set; }
        public int VisitPlanId { get; set; }

        [ForeignKey("AssigneeId")]
        public User Assignee { get; set; }
        [ForeignKey("ReporterId")]
        public User Reporter { get; set; }
        [ForeignKey("PlanUserId")]
        public User PlanUser { get; set; }
        [ForeignKey("TaskStatusId")]
        public TaskStatus TaskStatus { get; set; }
        [ForeignKey("VisitPlanId")]
        public VisitPlan VisitPlan { get; set; }
    }
}
