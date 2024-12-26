using System.ComponentModel.DataAnnotations.Schema;

namespace CDExellentAPI.Entities
{
    [Table("SurveyAssignee")]
    public class SurveyAssignee
    {
        public int SurveyRequestId { get; set; }
        public int AssigneeId { get; set; }
        public bool? IsFinished { get; set; }

        public SurveyRequest SurveyRequest { get; set; }
        public User Assignee { get; set; }
    }
}
