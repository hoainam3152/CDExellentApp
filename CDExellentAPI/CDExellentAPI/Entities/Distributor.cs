using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDExellentAPI.Entities
{
    [Table("Distributor")]
    public class Distributor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [StringLength(255)]
        public string Address { get; set; }
        [StringLength(10)]
        public string? PhoneNumber { get; set; }
        public int SalesManagementId { get; set; }
        public int? SalesId { get; set; }
        public bool Status { get; set; }
        [StringLength(20)]
        public string? AreaId { get; set; }

        [ForeignKey("SalesManagementId")]
        public User SalesManagement { get; set; }
        [ForeignKey("AreaId")]
        public Area Area { get; set; }

        public ICollection<VisitPlan> VisitPlans { get; set; }
    }
}
