using System.ComponentModel.DataAnnotations;

namespace CDExellentAPI.DTO.Requests
{
    public class QuestionUpdate
    {
        [Required]
        public string Content { get; set; }
        public bool? IsMultiSelect { get; set; }
        public string? ImagePath { get; set; }
    }
}
