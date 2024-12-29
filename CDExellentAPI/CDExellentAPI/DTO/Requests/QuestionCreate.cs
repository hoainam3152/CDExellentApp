using System.ComponentModel.DataAnnotations;

namespace CDExellentAPI.DTO.Requests
{
    public class QuestionCreate
    {
        [Required]
        public string Content { get; set; }
        public bool? IsMultiSelect { get; set; }
        public string? ImagePath { get; set; }
        [Required]
        public int SurveyId { get; set; }
    }
}
