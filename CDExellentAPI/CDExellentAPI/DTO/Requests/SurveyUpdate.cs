using System.ComponentModel.DataAnnotations;

namespace CDExellentAPI.DTO.Requests
{
    public class SurveyUpdate
    {
        [Required]
        public string Title { get; set; }
    }
}
