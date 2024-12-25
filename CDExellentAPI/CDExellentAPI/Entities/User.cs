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

        //User
        public ICollection<User> Managers { get; set; }
        //Distributor
        public ICollection<Distributor> Distributors { get; set; }
        //Guest
        public ICollection<Guest> Guests { get; set; }
        //Visit Plan
        public ICollection<VisitPlan> VisitPlans { get; set; }
        //Task
        public ICollection<Task> AssignedTasks { get; set; }
        public ICollection<Task> ReportedTasks { get; set; }
        public ICollection<Task> PlannedTasks { get; set; }
        //Delegation
        public ICollection<Delegation> Delegations { get; set; }
        //Media
        public ICollection<Media> Medias { get; set; }
        //Blog
        public ICollection<Blog> Blogs { get; set; }
        //Survey
        public ICollection<Survey> Surveys { get; set; }
    }
}
