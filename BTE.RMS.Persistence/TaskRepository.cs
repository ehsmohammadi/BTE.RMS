using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using BTE.RMS.Model.Tasks;

namespace BTE.RMS.Persistence
{
    public class TaskRepository : ITaskRepository
    {
        private readonly RMSContext ctx;

        public TaskRepository(RMSContext rmsContext)
        {
            this.ctx = rmsContext;
        }

        public void CreatTask(Task task)
        {
            ctx.Tasks.Add(task);
            ctx.SaveChanges();
        }

        public void CreatTaskCategory(TaskCategory taskCategory)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Task> GetAll()
        {
            return ctx.Tasks.Include("Category").ToList();
        }

        public IEnumerable<TaskCategory> GetAllCategories()
        {
            return ctx.TaskCategories.ToList();
        }

        public Task GetBy(long id)
        {
            return ctx.Tasks.Single(t => t.Id == id);
        }

        public TaskCategory GetCategoryBy(long id)
        {
            return ctx.TaskCategories.Single(t => t.Id == id);
        }

        public void DeleteBy(long id)
        {

            var task = ctx.Tasks.Single(t => t.Id == id);
            ctx.Tasks.Remove(task);
            ctx.SaveChanges();

        }

        public void Update(Task task)
        {
            ctx.SaveChanges();
        }

        public IEnumerable<Task> GetAllUnsyncForAndroidApp()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Task> GetAllUnsyncForDesktopApp()
        {
            throw new System.NotImplementedException();
        }
    }
}
