using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using BTE.RMS.Common;
using BTE.RMS.Model.Tasks;

namespace BTE.RMS.Persistence
{
    public class TaskRepository : ITaskRepository
    {
        #region Fields
        private readonly RMSContext ctx; 
        #endregion

        #region Constructors
        public TaskRepository(RMSContext rmsContext)
        {
            this.ctx = rmsContext;
        } 
        #endregion

        #region Public Methods

        public Task GetBy(long id)
        {
            return ctx.Tasks.Single(t => t.Id == id);
        }

        public Task GetBy(Guid syncId)
        {
            return ctx.Tasks.Single(t => t.SyncId == syncId);
        }

        public TaskCategory GetCategoryBy(long id)
        {
            return ctx.TaskCategories.Single(t => t.Id == id);
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
        #endregion

        #region Query Base Methods

        public IEnumerable<Task> GetAll()
        {
            return
                ctx.Tasks.AsNoTracking()
                    .Include("Category")
                    .Where(t => t.ActionType != EntityActionType.Delete)
                    .ToList();
        }

        public IEnumerable<TaskCategory> GetAllCategories()
        {
            return ctx.TaskCategories.AsNoTracking().ToList();
        }

        public List<Task> GetTaskByStartDate(DateTime startDate)
        {
            var res = ctx.Tasks.AsNoTracking().Where(t => t.StartDate.Date == startDate.Date);
            return res.ToList();

        }

        
        public IEnumerable<Task> GetAllUnsyncForAndroidApp()
        {
            var res = ctx.Tasks.AsNoTracking().Include("Category").Where(t => !t.SyncedWithAndriodApp);
            return res.ToList();
        }

        public IEnumerable<Task> GetAllUnsyncForDesktopApp()
        {
            var res = ctx.Tasks.AsNoTracking().Include("Category").Where(t => !t.SyncedWithDesktopApp);
            return res.ToList();
        }

        #endregion

    }
}
