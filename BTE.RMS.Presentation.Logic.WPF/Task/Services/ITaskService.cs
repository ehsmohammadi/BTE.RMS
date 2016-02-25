using System;
using System.Collections.Generic;
using BTE.Core;
using BTE.RMS.Interface.Contract.TaskItem;

namespace BTE.RMS.Presentation.Logic.Task
{
    public interface ITaskService:IService

    {
        void GetAll(Action<List<SummeryTaskItem>, Exception> action);
        void GetAllTaskCategory(Action<List<CrudTaskCategory>, Exception> action);
    }
}
