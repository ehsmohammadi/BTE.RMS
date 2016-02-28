using System;
using System.Collections.Generic;
using BTE.Core;
using BTE.RMS.Interface.Contract.DataTransferObject.TaskItem.Sync;
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
        void CreateTasks(SyncReuest syncReuest); 

        #endregion
        
    }
}
