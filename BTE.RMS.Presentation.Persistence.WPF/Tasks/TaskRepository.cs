using System;
using System.Collections.Generic;
using System.Linq;
using BTE.RMS.Common;
using BTE.RMS.Presentation.Logic.Tasks.Model;

namespace BTE.RMS.Presentation.Persistence.Tasks
{
    public class TaskRepository : ITaskRepository
    {

        #region Temp ...

        private static readonly List<Task> tasks = new List<Task>();

        private static readonly List<TaskCategory> taskCategories = new List<TaskCategory>();

        private static readonly List<TaskType> taskTypes=new  List<TaskType>
        {
            new TaskType
            {
                Id = 1,
                Title = "یادداشت"
            },
            new TaskType
            {
                Id = 1,
                Title = "قرار ملاقات"
            }
        };

        private long getNextId()
        {

            if (tasks.Count == 0)
            {
                return 1;
            }
            return tasks.Max(t => t.Id) + 1;
        }

        private long getNextCategoryId()
        {

            if (taskCategories.Count == 0)
            {
                return 1;
            }
            return taskCategories.Max(t => t.Id) + 1;
        }

        #endregion

        public IEnumerable<Task> GetAll()
        {
            return tasks;
        }

        public IEnumerable<TaskCategory> GetAllCategories()
        {
            return taskCategories;
        }

        public IEnumerable<Task> GetAllUnsync()
        {
            return tasks.Where(t => !t.IsSync).ToList();
        }

        public List<Task> GetTaskByStartDate(DateTime starDate)
        {
            throw new NotImplementedException();
        }

        public List<TaskType> GetAllTaskTypes()
        {
            return taskTypes;
        }

        public void CreatTask(Task task)
        {
            task.Id = getNextId();
            tasks.Add(task);
        }

        public void CreatTaskCategory(TaskCategory taskCategory)
        {
            taskCategory.Id = getNextCategoryId();
            taskCategories.Add(taskCategory);
        }

        public Task GetBy(long id)
        {
            return tasks.Single(t => t.Id == id);
        }

        public TaskCategory GetCategoryBy(long id)
        {
            return taskCategories.Single(t => t.Id == id);
        }

        public void DeleteBy(long id)
        {
            var task = GetBy(id);
            tasks.Remove(task);
        }

        public void Update(Task taskDes)
        {
            var task = GetBy(taskDes.Id);
            task.Update(taskDes.Title, taskDes.StartDate, taskDes.StartTime, taskDes.EndTime, taskDes.WorkProgressPercent, taskDes.Category, taskDes.ActionType);
            task.IsSync = taskDes.IsSync;
        }

    }
}
