using System.Data.Entity;
using System.Linq;
using BTE.RMS.Model.Attendees;
using BTE.RMS.Model.Meetings;
using BTE.RMS.Model.RMSFiles;
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
            this.Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<RMSContext, Configuration>());
        }

        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<User> Users { get; set; }

        //private DbSet<RMSFile> Files { get; set; }

        //public override int SaveChanges()
        //{
        //    this.Database.ExecuteSqlCommand("Delete ")
        //    return base.SaveChanges();

        //}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof(RMSContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
