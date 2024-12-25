using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CDExellentAPI.Entities
{
    [Table("Survey")]
    public class Survey
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        public int CreatorId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }

        [ForeignKey("CreatorId")]
        public User Creator { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
