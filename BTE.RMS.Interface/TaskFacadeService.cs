using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using AutoMapper;
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
        private readonly ITaskRepository taskRepository;

        #endregion

        #region Constructors
        public TaskFacadeService(ITaskService taskService,ITaskRepository taskRepository)
        {
            this.taskService = taskService;
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

        public IEnumerable<CrudTaskItem> GetAllUnSync(SyncReuest syncReuest)
        {
            switch ((DeviceType) syncReuest.DeviceType)
            {
                case DeviceType.AndriodApp:
                {
                    var res = taskRepository.GetAllUnsyncForAndroidApp();
                    return res.Select(RMSMapper.Map<Task, CrudTaskItem>).ToList();
                }
                case DeviceType.DesktopApp:
                {
                    var res = taskRepository.GetAllUnsyncForDesktopApp();
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

        #endregion
    }
}
