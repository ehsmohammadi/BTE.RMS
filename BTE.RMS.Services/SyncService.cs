using BTE.RMS.Services.Contract;
using BTE.RMS.Services.Contract.Synchronization;
using BTE.RMS.Services.Contract.Tasks;

namespace BTE.RMS.Services
{
    public class SyncService:ISyncService
    {
        private readonly ITaskService taskService;

        public SyncService(ITaskService taskService)
        {
            this.taskService = taskService;
        }


        public void SyncByCreate(ISyncCommand syncCommand)
        {
            throw new System.NotImplementedException();
        }
    }
}
