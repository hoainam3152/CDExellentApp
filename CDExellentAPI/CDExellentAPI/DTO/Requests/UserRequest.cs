using System.ComponentModel.DataAnnotations;

namespace CDExellentAPI.DTO.Requests
{
    public class UserRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        //[Required]
        public int TitleId { get; set; }
        //[Required]
        public bool Status { get; set; }
    }
}
