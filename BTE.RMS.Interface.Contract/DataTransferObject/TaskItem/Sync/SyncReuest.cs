using System.Collections.Generic;
using BTE.RMS.Interface.Contract.TaskItem;

namespace BTE.RMS.Interface.Contract.DataTransferObject.TaskItem.Sync
{
    public class SyncReuest
    {
        public int DeviceType { get; set; }

        public List<CrudTaskItem> TaskItems { get; set; } 
    }
}
