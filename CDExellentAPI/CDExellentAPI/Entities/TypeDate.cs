using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CDExellentAPI.Entities
{
    [Table("TypeDate")]
    public class TypeDate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(100)]
        public string Name { get; set; }

        public ICollection<VisitPlan> Plans { get; set; }
    }
}
