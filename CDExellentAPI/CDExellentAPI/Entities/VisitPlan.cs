using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDExellentAPI.Entities
{
    [Table("VisitPlan")]
    public class VisitPlan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public DateTime PlanDate { get; set; }
        public int TypeDateId { get; set; }
        public int DistributorId { get; set; }
        [StringLength(255)]
        public string Purpose { get; set; }
        public int PlanUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int PlanStatusId { get; set; }

        [ForeignKey("TypeDateId")]
        public TypeDate TypeDate { get; set; }
        [ForeignKey("DistributorId")]
        public Distributor Distributor { get; set; }
        [ForeignKey("PlanUserId")]
        public User PlanUser { get; set; }
        [ForeignKey("PlanStatusId")]
        public PlanStatus PlanStatus { get; set; }

        //Guest
        public ICollection<Guest> Guests { get; set; }
        //Task
        public ICollection<Task> Tasks { get; set; }
    }
}
