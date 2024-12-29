using System.ComponentModel.DataAnnotations;

namespace CDExellentAPI.DTO.Requests
{
    public class AnswerCreate
    {
        [Required]
        public string Content { get; set; }
        public int QuestionId { get; set; }
    }
}
