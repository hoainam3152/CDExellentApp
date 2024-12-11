using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDExellentAPI.Entities
{
    [Table("Area")]
    public class Area
    {
        [Key]
        [StringLength(20)]
        public string ID { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
    }
}
