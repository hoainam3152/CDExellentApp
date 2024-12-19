using System.ComponentModel.DataAnnotations;

namespace CDExellentAPI.DTO.Requests
{
    public class AreaUpdate
    {
        [Required]
        public string Name { get; set; }
    }
}
