using System.Collections.Generic;
using System.Data.Entity;
using BTE.RMS.Model.Tasks;

namespace BTE.RMS.Persistence
{
    public class RMSDBInitializer : CreateDatabaseIfNotExists<RMSContext>
    {
        protected override void Seed(RMSContext context)
        {

            IList<TaskCategory> categories = new List<TaskCategory>();

            categories.Add(new TaskCategory { Title = "کاری"});
            categories.Add(new TaskCategory { Title = "دوستان"});

            foreach (var category in categories)
                context.TaskCategories.Add(category);

            base.Seed(context);
        }
    }
}
