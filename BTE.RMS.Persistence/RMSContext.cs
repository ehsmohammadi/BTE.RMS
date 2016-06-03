using System.Data.Entity;
using BTE.RMS.Model.Attendees;
using BTE.RMS.Model.Meetings;
using BTE.RMS.Model.TaskCategories;
using BTE.RMS.Model.Tasks;
using BTE.RMS.Model.Users;
using BTE.RMS.Persistence.Migrations;


namespace BTE.RMS.Persistence
{
    public class RMSContext:DbContext
    {
        public RMSContext()
            : base("name=RMSConnection")
        {
            //Database.SetInitializer(new RMSDBInitializer());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<RMSContext, Configuration>());
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskCategory> TaskCategories { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof(RMSContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
