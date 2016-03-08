using System;
using System.Collections.Generic;
using BTE.Core;
using BTE.RMS.Interface.Contract.TaskItem;

namespace BTE.RMS.Interface.Contract.Facade
{
    public interface ITaskFacadeService:IFacadeService
    {
        List<SummeryTaskItem> GetAll();
        List<CrudTaskCategory> GetAllCategories();
        CrudTaskItem Get(long id);

        List<SummeryTaskItem> GetTaskByStartDate(DateTime selectedDate);

        CrudTaskItem Create(CrudTaskItem taskItem);
        CrudTaskItem Update(CrudTaskItem task);
        void Delete(long id);
        

        #region Sync

        IEnumerable<CrudTaskItem> GetAllUnSync(int deviceType);
        void SyncTasks(TaskSyncRequest syncReuest);
        void SyncTaskCategories(TaskCategorySyncRequest syncRequest);

        #endregion

        
    }
}
