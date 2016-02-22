using System.Collections.Generic;
using BTE.Core;
using BTE.RMS.Model.Tasks;

namespace BTE.RMS.Services.Contract
{
    public interface ITaskSyncService:IService
    {
        void SyncWithAndriodApp(IEnumerable<Task> tasks);
        void SyncWithDesktopApp(IEnumerable<Task> tasks);
    }
}
        