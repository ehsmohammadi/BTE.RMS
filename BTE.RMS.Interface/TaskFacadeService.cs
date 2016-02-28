using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using AutoMapper;
using BTE.RMS.Common;
using BTE.RMS.Interface.Contract.DataTransferObject.TaskItem.Sync;
using BTE.RMS.Interface.Contract.Facade;
using BTE.RMS.Interface.Contract.TaskItem;
using BTE.RMS.Model;
using BTE.RMS.Model.Tasks;
using BTE.RMS.Services.Contract;

namespace BTE.RMS.Interface
{
    public class TaskFacadeService : ITaskFacadeService
    {


        #region Temporary
        public static List<CrudTaskItem> taskItems = new List<CrudTaskItem>
        {
            new CrudTaskItem
                {
                    Id = 1,
                    Title = "طراحی واسط کاربری",
                    StartDate = DateTime.Now,
                    EndTime = DateTime.Now,
                    WorkProgressPercent = 70,
                    StartTime = DateTime.Now,
                    TaskItemType = TaskItemType.Note,
                    CategoryId = 1
                },

                new CrudTaskItem
                {
                    Id = 2,
                    Title = "jlsdkflsdk",
                    StartDate = DateTime.Now,
                    EndTime = DateTime.Now,
                    WorkProgressPercent = 70,
                    StartTime = DateTime.Now,
                    TaskItemType = TaskItemType.Note,
                    CategoryId = 1
                }
        };

        private static List<CrudTaskCategory> categories = new List<CrudTaskCategory>
        {
            new CrudTaskCategory{Id = 1,Title = "کار",Color = Color.White},
            new CrudTaskCategory{Id = 2,Title = "خانواده",Color = Color.White}
        };

        private long getNextId()
        {
            return taskItems.Max(t => t.Id) + 1;
        }
        #endregion

        #region Fields
        private readonly ITaskService taskService;
        private readonly ITaskSyncService taskSyncService;
        private readonly ITaskRepository taskRepository;

        #endregion

        #region Constructors
        public TaskFacadeService(ITaskService taskService,ITaskSyncService taskSyncService,ITaskRepository taskRepository)
        {
            this.taskService = taskService;
            this.taskSyncService = taskSyncService;
            this.taskRepository = taskRepository;
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
            var res=taskRepository.GetAllCategories();
            return res.Select(RMSMapper.Map<TaskCategory, CrudTaskCategory>).ToList(); 
        }

        public CrudTaskItem Get(long id)
        {
            var res=taskRepository.GetBy(id);
            return RMSMapper.Map<Task, CrudTaskItem>(res);
        }

        public CrudTaskItem Create(CrudTaskItem taskItem)
        {
            var taskCommand=RMSMapper.Map<CrudTaskItem, CreateTaskCommand>(taskItem);
            var task = taskService.CreateTask(taskCommand);
            var res = RMSMapper.Map<Task, CrudTaskItem>(task);
            return res;
        }

        public CrudTaskItem Update(CrudTaskItem taskItem)
        {
            var taskCommand = RMSMapper.Map<CrudTaskItem, UpdateTaskCommand>(taskItem);
            var task = taskService.UpdateTask(taskCommand);
            var res = RMSMapper.Map<Task, CrudTaskItem>(task);
            return res;
        }

        public void Delete(long id)
        {
            taskService.Delete(id);
        }

        public IEnumerable<CrudTaskItem> GetAllUnSync(int deviceType)
        {
            if(deviceType==0)
                throw new ArgumentException("syncet nulle agha mehdi", "deviceType");
            //syncReuest = new SyncReuest
            //{
            //    DeviceType = 1
            //};
            //todo:Change this section , decision mut not be set in this layer
            switch ((DeviceType) deviceType)
            {
                case DeviceType.AndriodApp:
                {
                    var res = taskRepository.GetAllUnsyncForAndroidApp().ToList();
                    taskSyncService.SyncWithAndriodApp(res);
                    return res.Select(RMSMapper.Map<Task, CrudTaskItem>).ToList();
                }
                case DeviceType.DesktopApp:
                {
                    var res = taskRepository.GetAllUnsyncForDesktopApp().ToList();
                    taskSyncService.SyncWithDesktopApp(res);
                    return res.Select(RMSMapper.Map<Task, CrudTaskItem>).ToList();
                }
                case DeviceType.All:
                {
                    var res = taskRepository.GetAll();
                    return res.Select(RMSMapper.Map<Task, CrudTaskItem>).ToList();
                }
                default:
                    return null;
            }
        }

        public void CreateTasks(SyncReuest syncReuest)
        {
            if (syncReuest == null)
                throw new ArgumentException("syncet nulle agha mehdi", "syncReuest");

            //syncReuest = new SyncReuest
            //{
            //    DeviceType = 1
            //};
            //todo:Change this section , decision mut not be set in this layer
            
            var tasks = syncReuest.TaskItems;
            foreach (var task in tasks)
            {
                var taskCommand = RMSMapper.Map<CrudTaskItem, CreateTaskCommand>(task);
                taskCommand.DeviceType = (DeviceType) syncReuest.DeviceType;
                taskService.CreateTask(taskCommand);
            }


        }

        #endregion
    }
}
