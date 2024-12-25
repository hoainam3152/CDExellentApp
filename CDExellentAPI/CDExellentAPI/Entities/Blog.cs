using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CDExellentAPI.Entities
{
    [Table("Blog")]
    public class Blog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(255)]
        public string? FilePath { get; set; }
        [StringLength(255)]
        public string? Description { get; set; }
        [StringLength(255)]
        public string? ImagePath { get; set; }
        public int CreatorId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }

        [ForeignKey("CreatorId")]
        public User Creator { get; set; }
    }
}
