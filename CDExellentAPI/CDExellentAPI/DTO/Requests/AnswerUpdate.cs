using System.ComponentModel.DataAnnotations;

namespace CDExellentAPI.DTO.Requests
{
    public class AnswerUpdate
    {
        [Required]
        public string Content { get; set; }
    }
}
