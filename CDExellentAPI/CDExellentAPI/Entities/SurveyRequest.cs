using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDExellentAPI.Entities
{
    [Table("SurveyRequest")]
    public class SurveyRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        public int SurveyId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [ForeignKey("SurveyId")]
        public Survey Survey { get; set; }

        public ICollection<SurveyAssignee> SurveyAssignees { get; set; }
    }
}
