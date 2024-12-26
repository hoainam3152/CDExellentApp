using Microsoft.EntityFrameworkCore;

namespace CDExellentAPI.Entities
{
    public class ManagementDbContext : DbContext
    {
        public ManagementDbContext(DbContextOptions options) : base(options) { }

        #region DbSet
        public DbSet<Area> Areas { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Distributor> Distributors { get; set; }
        public DbSet<TypeDate> TypeDates { get; set; }
        public DbSet<PlanStatus> PlanStatuses { get; set; }
        public DbSet<VisitPlan> Plans { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<TaskStatus> TaskStatuses { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Delegation> Delegations { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<SurveyRequest> SurveyRequests { get; set; }
        public DbSet<SurveyAssignee> SurveyAssignees { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Receive> Receives { get; set; }
        //public DbSet<Survey> Surveys { get; set; }
        //public DbSet<Survey> Surveys { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Guest
            modelBuilder.Entity<Guest>(entity =>
            {
                //Create many PK
                entity.HasKey(e => new { e.VisitPlanId, e.GuestUserId });

                //Create FK
                entity.HasOne(e => e.VisitPlan)
                    .WithMany(e => e.Guests)
                    .HasForeignKey(e => e.VisitPlanId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(e => e.GuestUser)
                    .WithMany(e => e.Guests)
                    .HasForeignKey(e => e.GuestUserId);
            });

            //User and Task
            modelBuilder.Entity<Task>(entity =>
            {
                entity.HasOne(e => e.Assignee)
                    .WithMany(e => e.AssignedTasks)
                    .HasForeignKey(e => e.AssigneeId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(e => e.Reporter)
                    .WithMany(e => e.ReportedTasks)
                    .HasForeignKey(e => e.ReporterId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(e => e.PlanUser)
                    .WithMany(e => e.PlannedTasks)
                    .HasForeignKey(e => e.PlanUserId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            //Visit Plan
            modelBuilder.Entity<VisitPlan>()
                .HasOne(e => e.PlanUser)
                .WithMany(e => e.VisitPlans)
                .HasForeignKey(e => e.PlanUserId)
                .OnDelete(DeleteBehavior.NoAction);

            //Distributor
            //Visit Plan
            modelBuilder.Entity<Distributor>()
                .HasOne(e => e.Area)
                .WithMany(e => e.Distributors)
                .HasForeignKey(e => e.AreaId)
                .OnDelete(DeleteBehavior.NoAction);

            //Delegation
            modelBuilder.Entity<Delegation>(entity =>
            {
                //Create many PK
                entity.HasKey(e => new { e.UserId, e.PermissionId });

                //Create FK
                entity.HasOne(e => e.User)
                    .WithMany(e => e.Delegations)
                    .HasForeignKey(e => e.UserId);

                entity.HasOne(e => e.Permission)
                    .WithMany(e => e.Delegations)
                    .HasForeignKey(e => e.PermissionId);
            });

            //SurveyAssignee
            modelBuilder.Entity<SurveyAssignee>(entity =>
            {
                //Create many PK
                entity.HasKey(e => new { e.SurveyRequestId, e.AssigneeId });

                //Create FK
                entity.HasOne(e => e.SurveyRequest)
                    .WithMany(e => e.SurveyAssignees)
                    .HasForeignKey(e => e.SurveyRequestId);

                entity.HasOne(e => e.Assignee)
                    .WithMany(e => e.SurveyAssignees)
                    .HasForeignKey(e => e.AssigneeId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            //Receive
            modelBuilder.Entity<Receive>(entity =>
            {
                //Create many PK
                entity.HasKey(e => new { e.NotificationId, e.ReceiverId });

                //Create FK
                entity.HasOne(e => e.Notification)
                    .WithMany(e => e.Receives)
                    .HasForeignKey(e => e.NotificationId);

                entity.HasOne(e => e.Receiver)
                    .WithMany(e => e.Receives)
                    .HasForeignKey(e => e.ReceiverId)
                    .OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}
