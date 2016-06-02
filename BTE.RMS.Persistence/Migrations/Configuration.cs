using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using BTE.RMS.Common;
using BTE.RMS.Model.TaskCategories;
using BTE.RMS.Model.Tasks;

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
