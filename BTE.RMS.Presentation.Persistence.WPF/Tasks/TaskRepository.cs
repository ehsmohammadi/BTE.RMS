﻿using System;
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

        private static readonly List<TaskCategory> taskCategories = new List<TaskCategory>
        {
            new TaskCategory
            {
                Id = 1,
                Title = "کاری"
            },
            new TaskCategory
            {
                Id = 2,
                Title = "دوستان"
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
            return tasks.Where(t=>t.ActionType!=EntityActionType.Delete);
        }

        public IEnumerable<TaskCategory> GetAllCategories()
        {
            return taskCategories;
        }

        public IEnumerable<Task> GetAllUnsync()
        {
            return tasks.Where(t => !t.SyncedWithServer).ToList();
        }

        public Task GetBy(Guid syncId)
        {
            return tasks.Single(t => t.SyncId == syncId);
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
            //var task = tasks.Find(t => t.Id == taskDes.Id);

            ////var task = GetBy(taskDes.Id);
            //task.Update(taskDes.Title, taskDes.StartDate, taskDes.StartTime, taskDes.EndTime, taskDes.WorkProgressPercent, taskDes.Category, taskDes.ActionType);
            //task.IsSync = taskDes.IsSync;
        }

    }
}
