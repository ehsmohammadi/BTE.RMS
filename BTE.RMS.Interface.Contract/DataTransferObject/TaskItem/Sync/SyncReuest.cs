using System.Collections.Generic;
using BTE.RMS.Interface.Contract.TaskItem;

namespace BTE.RMS.Interface.Contract
{
    public class SyncReuest
    {
        public int AppType { get; set; }

        
    }

    public class TaskSyncRequest : SyncReuest
    {
        public List<CrudTaskItem> TaskItems { get; set; } 
    }

    public class TaskCategorySyncRequest : SyncReuest
    {
        public List<CrudTaskCategory> TaskCategoryItems { get; set; }
    }

}
