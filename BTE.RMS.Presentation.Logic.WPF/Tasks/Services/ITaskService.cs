using System;
using System.Collections.Generic;
using BTE.Core;
using BTE.RMS.Interface.Contract.TaskItem;

namespace BTE.RMS.Presentation.Logic.Tasks.Services
{
    public interface ITaskService:IService

    {
        void GetAll(Action<List<SummeryTaskItem>, Exception> action);
        void GetAllTaskCategory(Action<List<CrudTaskCategory>, Exception> action);
        void GetAllTaskType(Action<List<TaskTypeDTO>, Exception> action);
        void GetBy(Action<CrudTaskItem, Exception> action, long id);
        void CreateTask(Action<CrudTaskItem, Exception> action, CrudTaskItem taskItem);
        void UpdateTask(Action<CrudTaskItem, Exception> action, CrudTaskItem taskItem);

        //sync section 

        CrudTaskItem CreateTask(CrudTaskItem crudTaskItem,bool syncWithServer);

        CrudTaskItem UpdateTask(CrudTaskItem crudTaskItem, bool syncWithServer);
        
    }
}
