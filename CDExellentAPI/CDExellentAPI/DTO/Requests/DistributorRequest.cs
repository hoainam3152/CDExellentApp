using System.ComponentModel.DataAnnotations;

namespace CDExellentAPI.DTO.Requests
{
    public class DistributorRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        public string? PhoneNumber { get; set; }
        [Required]
        public int SalesManagementId { get; set; }
        public int? SalesId { get; set; }
        public bool Status { get; set; }
        [Required]
        public string? AreaId { get; set; }
    }
}
