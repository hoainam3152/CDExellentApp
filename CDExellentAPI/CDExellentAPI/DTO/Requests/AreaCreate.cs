using System.ComponentModel.DataAnnotations;

namespace CDExellentAPI.DTO.Requests
{
    public class AreaCreate
    {
        [Required]
        public string ID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
