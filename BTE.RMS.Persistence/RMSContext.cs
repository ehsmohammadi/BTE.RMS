using System.Data.Entity;
using BTE.RMS.Model.Tasks;


namespace BTE.RMS.Persistence
{
    public class RMSContext:DbContext
    {
        public RMSContext()
            : base("name=RMSConnection")
        {
            Database.SetInitializer(new RMSDBInitializer());
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskCategory> TaskCategories { get; set; }
    }
}
