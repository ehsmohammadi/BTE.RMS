using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using AutoMapper;
using BTE.RMS.Common;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Interface.Contract.Facade;
using BTE.RMS.Interface.Contract.TaskItem;
using BTE.RMS.Model;
using BTE.RMS.Model.TaskCategories;
using BTE.RMS.Model.Tasks;
using BTE.RMS.Services.Contract;
using BTE.RMS.Services.Contract.Synchronization;
using BTE.RMS.Services.Contract.Tasks;

namespace BTE.RMS.Interface
{
    public class TaskFacadeService : ITaskFacadeService
    {


        #region Fields
        private readonly ITaskService taskService;
        private readonly ITaskSyncService taskSyncService;
        private readonly ITaskRepository taskRepository;
        private readonly ISyncService syncService;
        private readonly ITaskCategoryRepository taskCategoryRepository;

        #endregion

        #region Constructors

        public TaskFacadeService(ITaskService taskService, ITaskSyncService taskSyncService,
            ITaskRepository taskRepository, ISyncService syncService, ITaskCategoryRepository taskCategoryRepository)
        {
            this.taskService = taskService;
            this.taskSyncService = taskSyncService;
            this.taskRepository = taskRepository;
            this.syncService = syncService;
            this.taskCategoryRepository = taskCategoryRepository;
        }

        #endregion

        #region Public Methods

        public List<SummeryTaskItem> GetAll()
        {
            var res = taskRepository.GetAll();
            return res.Select(RMSMapper.Map<Task, SummeryTaskItem>).ToList();
        }

        public List<CrudTaskCategory> GetAllCategories()
        {
            var res = taskCategoryRepository.GetAll();
            return res.Select(RMSMapper.Map<TaskCategory, CrudTaskCategory>).ToList();
        }

        public CrudTaskItem Get(long id)
        {
            var res = taskRepository.GetBy(id);
            return RMSMapper.Map<Task, CrudTaskItem>(res);
        }

        public List<SummeryTaskItem> GetTaskByStartDate(DateTime starDate)
        {
            var res = taskRepository.GetTaskByStartDate(starDate);
            return res.Select(RMSMapper.Map<Task, SummeryTaskItem>).ToList();
        }

        public CrudTaskItem Create(CrudTaskItem taskItem)
        {
            var taskCommand = RMSMapper.Map<CrudTaskItem, CreateTaskCommand>(taskItem);
            taskCommand.AppType=AppType.WebApp;
            var task = taskService.CreateTask(taskCommand);
            var res = RMSMapper.Map<Task, CrudTaskItem>(task);
            return res;
        }

        public CrudTaskItem Update(CrudTaskItem taskItem)
        {
            var taskCommand = RMSMapper.Map<CrudTaskItem, UpdateTaskCommand>(taskItem);
            taskCommand.AppType = AppType.WebApp;
            var task = taskService.UpdateTask(taskCommand);
            var res = RMSMapper.Map<Task, CrudTaskItem>(task);
            return res;
        }

        public void Delete(long id)
        {
            taskService.DeleteTask(new DeleteTaskCommand{AppType = AppType.WebApp,Id = id});
        }


        #endregion

        #region Sync Mehtods
        public IEnumerable<CrudTaskItem> GetAllUnSync(int deviceType)
        {
            if (deviceType == 0)
                throw new ArgumentException("syncet nulle agha mehdi", "deviceType");
            //syncReuest = new SyncReuest
            //{
            //    DeviceType = 1
            //};
            //todo:Change this section , decision mut not be set in this layer
            switch ((AppType)deviceType)
            {
                case AppType.AndriodApp:
                    {
                        var res = taskRepository.GetAllUnsyncForAndroidApp().ToList();
                        taskSyncService.SyncWithAndriodApp(res);
                        return res.Select(RMSMapper.Map<Task, CrudTaskItem>).ToList();
                    }
                case AppType.DesktopApp:
                    {
                        var res = taskRepository.GetAllUnsyncForDesktopApp().ToList();
                        taskSyncService.SyncWithDesktopApp(res);
                        return res.Select(RMSMapper.Map<Task, CrudTaskItem>).ToList();
                    }
                case AppType.All:
                    {
                        var res = taskRepository.GetAll();
                        return res.Select(RMSMapper.Map<Task, CrudTaskItem>).ToList();
                    }
                default:
                    return null;
            }
        }

        public void SyncTasks(TaskSyncRequest syncReuest)
        {
            if (syncReuest == null)
                throw new ArgumentException("syncRequest can't be null", "syncReuest");

            //todo: bad code here foreach and if :(
            var appType = (AppType)syncReuest.AppType;
            foreach (var taskItem in syncReuest.TaskItems)
            {

                if (taskItem.ActionType == (int)EntityActionType.Create)
                {
                    var taskCommand = RMSMapper.Map<CrudTaskItem, CreateTaskCommand>(taskItem);
                    taskCommand.AppType = appType;
                    taskService.CreateTask(taskCommand);

                }
                if (taskItem.ActionType == (int)EntityActionType.Modify)
                {
                    var taskCommand = RMSMapper.Map<CrudTaskItem, UpdateTaskCommand>(taskItem);
                    taskCommand.AppType = appType;
                    taskService.UpdateTask(taskCommand);
                }
                if (taskItem.ActionType == (int)EntityActionType.Delete)
                {
                    var taskCommand = RMSMapper.Map<CrudTaskItem, DeleteTaskCommand>(taskItem);
                    taskCommand.AppType = appType;
                    taskService.DeleteTask(taskCommand); 
                }

            }
        }

        public void SyncTaskCategories(TaskCategorySyncRequest syncRequest)
        {
            //var syncItems = syncRequest.TaskCategoryItems;
            var commands = new List<ISyncCommand>();
            foreach (var category in syncRequest.TaskCategoryItems)
            {
                if (category.ActionType == (int)EntityActionType.Create)
                {
                    var syncCommand = new SyncCommand
                    {
                        //ActionTypeOwner = (AppType)syncRequest.AppType,
                        SyncId = category.SyncId,
                        //Data = new CreateTaskCategoryCommand
                        //{
                        //    Title = category.Title
                        //}
                    };
                    syncService.SyncByCreate(syncCommand);
                    //commands.Add(new SyncCommand<CreateTaskCategoryCommand>
                    //{
                    //    ActionTypeOwner = (AppType) syncRequest.AppType,
                    //    SyncId = category.SyncId,
                    //    Data = new CreateTaskCategoryCommand
                    //    {
                    //        Title = category.Title
                    //    }
                    //});
                }
            }

            //var syncCommands = syncItems.Select(i => new SyncCommand<TaskCategory>
            //{

            //    SyncId = i.SyncId,
            //    ActionTypeOwner = (AppType) syncRequest.AppType,
            //    Data =,
            //});

        }

        #endregion
    }


}
