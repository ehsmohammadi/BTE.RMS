using System;
using System.Collections.Generic;
using System.Linq;
using BTE.Core;
using BTE.Presentation;
using BTE.RMS.Common;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Interface.Contract.TaskItem;
using BTE.RMS.Presentation.Logic.Tasks.Model;
using BTE.RMS.Presentation.Logic.Tasks.Services;

namespace BTE.RMS.Presentation.Logic
{
    public class SyncService : ISyncService
    {
        private readonly Guid id;

        public Guid Id
        {
            get { return id; }
        }

        #region Fields
        private Uri apiUri = new Uri(RMSClientConfig.BaseApiAddress);
        private readonly ITaskService taskService;
        private readonly ITaskRepository taskRepository;
        private readonly IEventPublisher publisher;
        private DelegateHandler<TaskSyncCompleted> taskSyncedCompletedHandler;
        private DelegateHandler<ServerTaskSyncCompleted> serverTaskSyncCompletedHandler;

        #endregion

        #region Constructors
        public SyncService(ITaskService taskService, ITaskRepository taskRepository, IEventPublisher publisher)
        {
            this.taskService = taskService;
            this.taskRepository = taskRepository;
            this.publisher = publisher;
            id=Guid.NewGuid();
        }

        #endregion

        #region Public methods
        public void Sync(Action<string, Exception> action)
        {
            #region SyncCompletedHandler

            serverTaskSyncCompletedHandler = new DelegateHandler<ServerTaskSyncCompleted>(e =>
            {
                sendTaskToServer();
                

            });
            publisher.RegisterHandler(serverTaskSyncCompletedHandler);


            taskSyncedCompletedHandler = new DelegateHandler<TaskSyncCompleted>(e =>
                {
                    publisher.UnregisterHandler(serverTaskSyncCompletedHandler);
                    publisher.UnregisterHandler(taskSyncedCompletedHandler);
                    action("syncCompleted", null);
                    
                });
            publisher.RegisterHandler(taskSyncedCompletedHandler);

            #endregion

            getTasksFromServer();
        }

        #endregion

        #region private methods
        private void getTasksFromServer()
        {
            RMSHttpClient.Get<List<CrudTaskItem>>((res, exp) =>
            {
                if (exp == null)
                {
                    insertServerTasks(res);
                }
            }, apiUri, "TaskSync?DeviceType=2");

        }

        private void insertServerTasks(IEnumerable<CrudTaskItem> taskItems)
        {
            foreach (var taskItem in taskItems)
            {
                if (taskItem.ActionType == (int)EntityActionType.Create)
                    taskService.CreateTask(taskItem, true);
                if (taskItem.ActionType == (int)EntityActionType.Modify)
                    taskService.UpdateTask(taskItem, true);
                if (taskItem.ActionType == (int)EntityActionType.Delete)
                    taskService.DeleteTask(taskItem, true);
                
            }
            publisher.Publish(new ServerTaskSyncCompleted());
        }

        private void sendTaskToServer()
        {
            var unSyncTask = taskRepository.GetAllUnsync().ToList();
            var syncRequest = new TaskSyncRequest
            {
                AppType = (int)AppType.DesktopApp,
                TaskItems = unSyncTask.Select(RMSMapper.Map<Task, CrudTaskItem>).ToList()
            };
            RMSHttpClient.Post<Object, SyncReuest>((res, exp) =>
            {
                if (exp == null)
                {
                    updateLocalTasks(unSyncTask);
                }
            }, apiUri, "TaskSync", syncRequest);

        }

        private void updateLocalTasks(IList<Task> tasks)
        {
            foreach (var unSyncTask in tasks)
            {
                var task = taskRepository.GetBy(unSyncTask.Id);
                task.SyncWithServer();
                taskRepository.Update(task);
            }
            publisher.Publish(new TaskSyncCompleted());
        }

        #endregion
    }
}
