using System.Collections.Generic;
using BTE.RMS.Model.Tasks;
using BTE.RMS.Services.Contract;

namespace BTE.RMS.Services
{
    public class TaskSyncService:ITaskSyncService
    {
        private readonly ITaskRepository taskRepository;

        public TaskSyncService(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        public void SyncWithAndriodApp(IEnumerable<Task> tasks)
        {
            foreach (var task in tasks)
            {
                var unsynctask = taskRepository.GetBy(task.Id);
                unsynctask.SyncWithAndriodApp();
                taskRepository.Update(unsynctask);
            }            
        }

        public void SyncWithDesktopApp(IEnumerable<Task> tasks)
        {
            foreach (var task in tasks)
            {
                var unsynctask = taskRepository.GetBy(task.Id);
                unsynctask.SyncWithDesktopApp();
                taskRepository.Update(unsynctask);
            }
        }
    }
}
