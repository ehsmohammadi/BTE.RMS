using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BTE.RMS.Common;
using BTE.RMS.Model.TaskCategories;
using BTE.RMS.Model.Tasks;

namespace BTE.RMS.Persistence
{
    public class RMSDBInitializer : DropCreateDatabaseIfModelChanges<RMSContext>
    {
        protected override void Seed(RMSContext context)
        {
            var categories = new List<TaskCategory>
            {
                new TaskCategory("Work",Guid.NewGuid(),AppType.WebApp),
                new TaskCategory("Friends",Guid.NewGuid(),AppType.WebApp)
            };
            foreach (var category in categories)
                context.TaskCategories.Add(category);

            var tasks = new List<Task>
            {
                               new Task("نکته آموزشی", DateTime.Now, DateTime.Now, DateTime.Now,
                    "بررسی اعماق زمین برای رسیدگی به موضوع", 33, categories.First(), AppType.WebApp, Guid.NewGuid()),
                new Task("جلسه هفتگی با مدیران", DateTime.Now, DateTime.Now, DateTime.Now,
                    "بررسی روند اقتصادی صنایع جهش محور", 33, categories.First(), AppType.WebApp, Guid.NewGuid())            };

            foreach (var task in tasks)
                context.Tasks.Add(task);


            base.Seed(context);
        }
    }
}
