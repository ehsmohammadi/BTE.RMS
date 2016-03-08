using System.Collections.Generic;
using BTE.RMS.Common;
using BTE.RMS.Model.Tasks;

namespace BTE.RMS.Persistence.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RMSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(RMSContext context)
        {
            var categories = new List<TaskCategory>
            {
                new TaskCategory("Work",Guid.NewGuid(),false,false,AppType.WebApp),
                new TaskCategory("Friends",Guid.NewGuid(),false,false,AppType.WebApp)

            };
            foreach (var category in categories)
                context.TaskCategories.AddOrUpdate(category);

            var tasks = new List<Task>
            {
                new Task("نکته آموزشی", DateTime.Now, DateTime.Now, DateTime.Now,
                    "بررسی اعماق زمین برای رسیدگی به موضوع", 33, categories.First(), AppType.WebApp, Guid.NewGuid()),
                new Task("جلسه هفتگی با مدیران", DateTime.Now, DateTime.Now, DateTime.Now,
                    "بررسی روند اقتصادی صنایع جهش محور", 33, categories.First(), AppType.WebApp, Guid.NewGuid())
            };

            foreach (var task in tasks)
                context.Tasks.AddOrUpdate(task);


            base.Seed(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
