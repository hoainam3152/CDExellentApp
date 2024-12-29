using System.ComponentModel.DataAnnotations;

namespace CDExellentAPI.DTO.Requests
{
    public class BlogCreate
    {
        [Required]
        public string Title { get; set; }
        public string? FilePath { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
        [Required]
        public int CreatorId { get; set; }
    }
}
