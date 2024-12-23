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
        //public DbSet<Area> Areas { get; set; }
        //public DbSet<Area> Areas { get; set; }
        //public DbSet<Area> Areas { get; set; }
        //public DbSet<Area> Areas { get; set; }
        //public DbSet<Area> Areas { get; set; }
        //public DbSet<Area> Areas { get; set; }
        //public DbSet<Area> Areas { get; set; }
        //public DbSet<Area> Areas { get; set; }
        //public DbSet<Area> Areas { get; set; }
        //public DbSet<Area> Areas { get; set; }
        //public DbSet<Area> Areas { get; set; }
        //public DbSet<Area> Areas { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
