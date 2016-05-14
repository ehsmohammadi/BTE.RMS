using System.Data.Entity;
using BTE.RMS.Model.Meetings;
using BTE.RMS.Model.TaskCategories;
using BTE.RMS.Model.Tasks;


namespace BTE.RMS.Persistence
{
    public class RMSContext:DbContext
    {
        public RMSContext()
            : base("name=RMSConnection")
        {
            Database.SetInitializer(new RMSDBInitializer());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<RMSContext, Configuration>());
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskCategory> TaskCategories { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
    }
}
