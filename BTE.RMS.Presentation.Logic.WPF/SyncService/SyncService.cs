using System;
using BTE.Core;
using BTE.Presentation;
using BTE.RMS.Interface.Contract.TaskItem;
using BTE.RMS.Presentation.Logic.Tasks.Services;

namespace BTE.RMS.Presentation.Logic
{
    public class SyncService : ISyncService
    {
        #region Fields

        private readonly ITaskService taskService;
        private readonly IEventPublisher publisher;
        private DelegateHandler<TaskSyncCompleted> taskSyncedCompletedHandler;

        #endregion

        #region Constructors
        public SyncService(ITaskService taskService, IEventPublisher publisher)
        {
            this.taskService = taskService;
            this.publisher = publisher;
        }

        #endregion

        #region Public methods
        public void Sync(Action<string, Exception> action)
        {
            #region SyncCompletedHandler

            taskSyncedCompletedHandler = new DelegateHandler<TaskSyncCompleted>(e =>
                {
                    action("syncCompleted", null);
                });
            publisher.RegisterHandler(taskSyncedCompletedHandler); 

            #endregion
        }
        #endregion

        #region private methods
        private void syncTasks()
        {

            
        }


        #endregion
    }
}
