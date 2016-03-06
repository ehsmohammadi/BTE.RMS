using System;
using System.Collections.Generic;
using System.Linq;
using BTE.Core;
using BTE.Presentation;
using BTE.RMS.Common;
using BTE.RMS.Interface.Contract.DataTransferObject.TaskItem.Sync;
using BTE.RMS.Interface.Contract.TaskItem;
using BTE.RMS.Presentation.Logic.Tasks.Model;
using BTE.RMS.Presentation.Logic.Tasks.Services;

namespace BTE.RMS.Presentation.Logic
{
    public class SyncService : ISyncService
    {
        #region Fields
        private Uri apiUri = new Uri(RMSClientConfig.BaseApiAddress);
        private readonly ITaskService taskService;
        private readonly ITaskRepository taskRepository;
        private readonly IEventPublisher publisher;
        private DelegateHandler<TaskSyncCompleted> taskSyncedCompletedHandler;

        #endregion

        #region Constructors
        public SyncService(ITaskService taskService,ITaskRepository taskRepository, IEventPublisher publisher)
        {
            this.taskService = taskService;
            this.taskRepository = taskRepository;
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
                    syncTaskToServer();
                });
            publisher.RegisterHandler(taskSyncedCompletedHandler); 

            #endregion

            syncTasksFromServer();
        }

        #endregion

        #region private methods
        private void syncTasksFromServer()
        {
            RMSHttpClient.Get<List<CrudTaskItem>>((res, exp) =>
            {
                if (exp==null)
                {
                    insertServerTasks(res);
                }
            },apiUri,"TaskSync?DeviceType=2");
            
        }

        private void insertServerTasks(IEnumerable<CrudTaskItem> taskItems)
        {
            foreach (var taskItem in taskItems)
            {
                taskService.CreateTask(taskItem, true);
            }
            publisher.Publish(new TaskSyncCompleted());
        }

        private void syncTaskToServer()
        {
            var unSyncTask = taskRepository.GetAllUnsync().ToList();
            var syncRequest = new SyncReuest
            {
                DeviceType = (int)DeviceType.DesktopApp,
                TaskItems = unSyncTask.Select(RMSMapper.Map<Task, CrudTaskItem>).ToList()
            };
            RMSHttpClient.Post<Object,SyncReuest>((res, exp) =>
            {
                if (exp == null)
                {
                    syncLocalTasks(unSyncTask);
                }
            }, apiUri, "TaskSync",syncRequest);

        }

        private void syncLocalTasks(IList<Task> tasks)
        {
            foreach (var unSyncTask in tasks)
            {
                var task = taskRepository.GetBy(unSyncTask.Id);
                task.SyncWithServer();
                taskRepository.Update(task);
            }
        }

        #endregion
    }
}
