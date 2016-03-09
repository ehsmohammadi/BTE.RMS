using BTE.Core;

namespace BTE.RMS.Presentation.Logic
{
    public class TaskSyncCompleted:IDomainEvent<TaskSyncCompleted>
    {
        public TaskSyncCompleted()
        {
            
        }

        public bool SameEventAs(TaskSyncCompleted other)
        {
            return true;
        }
    }

    public class ServerTaskSyncCompleted : IDomainEvent<ServerTaskSyncCompleted>
    {
        public ServerTaskSyncCompleted()
        {

        }

        public bool SameEventAs(ServerTaskSyncCompleted other)
        {
            return true;
        }
    }
}
