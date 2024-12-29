using System.ComponentModel.DataAnnotations;

namespace CDExellentAPI.DTO.Requests
{
    public class SurveyCreate
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public int CreatorId { get; set; }
    }
}
