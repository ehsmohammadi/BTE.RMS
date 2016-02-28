using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using BTE.RMS.Interface.Contract.TaskItem;

namespace BTE.RMS.Presentation.Logic.Task
{
    public class TaskService : ITaskService
    {
        #region Temprory
        private static List<TaskTypeDTO> taskTypeList = new List<TaskTypeDTO>
        {
            new TaskTypeDTO
            {
                Id = 1,
                Title = "یادداشت"
            },
            new TaskTypeDTO
            {
                Id = 2,
                Title = "قرار ملاقات"
            },
        };

        private static List<CrudTaskCategory> taskCategoryList = new List<CrudTaskCategory>
        {
            new CrudTaskCategory
            {
                Id = 1,
                Title = "کاری",
                Color = Color.Aqua,
            },
            new CrudTaskCategory
            {
                Id = 2,
                Title = "دوستان",
                Color = Color.Aqua,
            }
        };

        private static List<CrudTaskItem> taskItemList = new List<CrudTaskItem>
        {
            new CrudTaskItem
            {
                Id = 1,
                CategoryId = taskCategoryList.First().Id,
                TaskTypeId = taskTypeList.First().Id,
                Title = "علی",
                WorkProgressPercent = 20,
                StartDate = new DateTime?(DateTime.Now)
            },
            new CrudTaskItem
            {
                Id = 2,
                CategoryId = taskCategoryList.First().Id,
                TaskTypeId = taskTypeList.First().Id,
                Title = "علی",
                WorkProgressPercent = 20,
                StartDate = DateTime.Now
            },
            new CrudTaskItem
            {
                Id = 3,
                CategoryId = taskCategoryList.First().Id,
                TaskTypeId = taskTypeList.First().Id,
                Title = "علی",
                WorkProgressPercent = 20,
                StartDate = DateTime.Now
            },
        };

        private long getNextId()
        {

            if (taskItemList.Count == 0)
            {
                return 1;
            }
            return taskItemList.Max(t => t.Id) + 1;
        }

        #endregion

        public void GetAll(Action<List<SummeryTaskItem>, Exception> action)
        {
            action(taskItemList.Select(t => new SummeryTaskItem
            {
                Id = t.Id,
                Title = t.Title,
                TaskTypeId = t.TaskTypeId,
                CategoryTitle = taskCategoryList.Single(tc => tc.Id == t.CategoryId).Title,
                EndTime = t.EndTime,
                StartDate = t.StartDate,
                WorkProgressPercent = t.WorkProgressPercent,
                StartTime = t.StartTime,
                SyncId = t.SyncId
            }).ToList(), null);

        }

        public void GetAllTaskCategory(Action<List<CrudTaskCategory>, Exception> action)
        {
            action(taskCategoryList, null);
        }

        public void GetAllTaskType(Action<List<TaskTypeDTO>, Exception> action)
        {
            action(taskTypeList, null);
        }

        public void GetBy(Action<CrudTaskItem, Exception> action, long id)
        {
            var task=taskItemList.Single(s => s.Id == id);
            action(task, null);
        }

        public void CreateTask(Action<CrudTaskItem, Exception> action, CrudTaskItem taskItem)
        {
            taskItem.Id = getNextId();
            taskItemList.Add(taskItem);
            action(taskItem, null);
        }
    }

}
