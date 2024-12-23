using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDExellentAPI.Entities
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [StringLength(20)]
        public int TitleId { get; set; }
        [StringLength(20)]
        public string? AreaId { get; set; }
        public bool Status { get; set; }
        public int? ManagerId { get; set; }
        [StringLength(10)]
        public string? PhoneNumber { get; set; }
        [StringLength(255)]
        public string? Address { get; set; }
        [StringLength(255)]
        public string Password { get; set; }

        [ForeignKey("TitleId")]
        public Title Title { get; set; }
        [ForeignKey("AreaId")]
        public Area Area { get; set; }
        [ForeignKey("ManagerId")]
        public User Manager { get; set; }

        public ICollection<User> Managers { get; set; }
        public ICollection<Distributor> Distributors { get; set; }
    }
}
