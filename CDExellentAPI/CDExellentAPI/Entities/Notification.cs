using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CDExellentAPI.Entities
{
    [Table("Notification")]
    public class Notification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        public string Content { get; set; }
        public int CreatorId { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("CreatorId")]
        public User Creator { get; set; }

        public ICollection<Receive> Receives { get; set; }
    }
}
