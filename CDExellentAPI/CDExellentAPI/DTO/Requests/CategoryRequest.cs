using System.ComponentModel.DataAnnotations;

namespace CDExellentAPI.DTO.Requests
{
    public class CategoryRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
