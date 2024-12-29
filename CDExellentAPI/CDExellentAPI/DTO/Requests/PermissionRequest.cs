using System.ComponentModel.DataAnnotations;

namespace CDExellentAPI.DTO.Requests
{
    public class PermissionRequest
    {
        [Required]
        public string Name { get; set; }
        public int ModuleId { get; set; }
    }
}
