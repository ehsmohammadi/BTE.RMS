using System.Data.Entity.Migrations;

namespace BTE.RMS.Persistence.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<RMSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(RMSContext context)
        {
            base.Seed(context);
        }
    }
}
