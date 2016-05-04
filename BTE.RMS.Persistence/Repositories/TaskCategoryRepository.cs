using System;
using System.Collections.Generic;
using System.Linq;
using BTE.RMS.Common;
using BTE.RMS.Model.TaskCategories;

namespace BTE.RMS.Persistence
{
    public class TaskCategoryRepository : ITaskCategoryRepository
    {
        #region Fields
        private readonly RMSContext ctx;
        #endregion

        #region Constructors
        public TaskCategoryRepository(RMSContext rmsContext)
        {
            this.ctx = rmsContext;
        }
        #endregion

        #region Public Methods

        public IList<TaskCategory> GetAll()
        {
            return
                ctx.TaskCategories.AsNoTracking()

                    .Where(t => t.ActionType != EntityActionType.Delete)
                    .ToList();

        }

        public TaskCategory GetBy(long id)
        {
            return ctx.TaskCategories.Single(t => t.Id == id);
        }

        public void Create(TaskCategory taskCategory)
        {
            ctx.TaskCategories.Add(taskCategory);
            ctx.SaveChanges();
        }

        public void Update(TaskCategory taskCategory)
        {
            ctx.SaveChanges();
        }

        public void Delete(TaskCategory taskCategory)
        {
            ctx.TaskCategories.Remove(taskCategory);
            ctx.SaveChanges();
        }

        public TaskCategory GetBy(Guid syncId)
        {
            return ctx.TaskCategories.Single(t => t.SyncId == syncId);
        }

        #endregion

    }
}
