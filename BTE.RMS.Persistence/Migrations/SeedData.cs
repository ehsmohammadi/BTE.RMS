using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BTE.RMS.Common;
using BTE.RMS.Model.Tasks;

namespace BTE.RMS.Persistence
{
    public class RMSDBInitializer : DropCreateDatabaseIfModelChanges<RMSContext>
    {
        protected override void Seed(RMSContext context)
        {
            var categories = new List<TaskCategory>
            {
                new TaskCategory {Title = "کاری"},
                new TaskCategory {Title = "دوستان"}
            };
            foreach (var category in categories)
                context.TaskCategories.Add(category);

            var tasks = new List<Task>
            {
                new Task("نکته آموزشی", 33, DateTime.Now, DateTime.Now, DateTime.Now,categories.First(),DeviceType.WebApp),
                new Task("برگه خرید", 33, DateTime.Now, DateTime.Now, DateTime.Now,categories.First(),DeviceType.WebApp)
            };

            foreach (var task in tasks)
                context.Tasks.Add(task);


            base.Seed(context);
        }
    }
}
