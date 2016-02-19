using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using AutoMapper;
using BTE.RMS.Interface.Contract.Facade;
using BTE.RMS.Interface.Contract.TaskItem;
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
        #endregion

        #region Constructors
        public TaskFacadeService(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        #endregion

        #region Public Methods
        public List<SummeryTaskItem> GetAll()
        {
            var summeryTasks =
                taskItems.Select(
                    t =>
                        new SummeryTaskItem
                        {
                            CategoryTitle = categories.Single(c => c.Id == t.CategoryId).Title,
                            Id = t.Id,
                            Title = t.Title,
                            EndTime = t.EndTime,
                            StartDate = t.StartDate,
                            TaskItemType = t.TaskItemType,
                            WorkProgressPercent = t.WorkProgressPercent,
                            StartTime = t.StartTime
                        }).ToList();
            return summeryTasks;
        }

        public List<CrudTaskCategory> GetAllCategories()
        {
            return categories;
        }

        public CrudTaskItem Get(long id)
        {
            return taskItems.Find(t => t.Id == id);
        }

        public CrudTaskItem Create(CrudTaskItem taskItem)
        {
            var taskCommand=RMSMapper.Map<CrudTaskItem, CreateTaskCommand>(taskItem);
            var task = taskService.CreateTask(taskCommand);
            var res=RMSMapper.Map<Task, CrudTaskItem>(task);
            return res;
        }

        public CrudTaskItem Update(CrudTaskItem task)
        {
            var sourceTask = taskItems.Single(t => t.Id == task.Id);
            sourceTask.CategoryId = task.CategoryId;
            sourceTask.Title = task.Title;
            sourceTask.EndTime = task.EndTime;
            sourceTask.StartDate = task.StartDate;
            sourceTask.StartTime = task.StartTime;
            sourceTask.EndTime = task.EndTime;
            sourceTask.WorkProgressPercent = task.WorkProgressPercent;
            return sourceTask;
        }

        public void Delete(long id)
        {
            taskItems.Remove(taskItems.Find(t => t.Id == id));
        }
        #endregion
    }
}
