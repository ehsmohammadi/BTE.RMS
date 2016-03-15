using System;
using System.Collections.Generic;
using BTE.Core;
using BTE.RMS.Model.TaskCategories;

namespace BTE.RMS.Model.Tasks
{
    public interface ITaskRepository : ISyncRepository<Task>
    {
        IEnumerable<Task> GetAllUnsyncForAndroidApp();
        IEnumerable<Task> GetAllUnsyncForDesktopApp();
        List<Task> GetTaskByStartDate(DateTime starDate);
    }
}
