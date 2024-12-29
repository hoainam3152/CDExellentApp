using System.ComponentModel.DataAnnotations;

namespace CDExellentAPI.DTO.Requests
{
    public class ModuleRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
