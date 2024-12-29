using System.ComponentModel.DataAnnotations;

namespace CDExellentAPI.DTO.Requests
{
    public class SurveyAssigneeRequest
    {
        [Required]
        public int SurveyRequestId { get; set; }
        [Required]
        public int AssigneeId { get; set; }
    }
}
