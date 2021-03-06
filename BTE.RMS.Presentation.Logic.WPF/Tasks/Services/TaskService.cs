﻿using System;
using System.Collections.Generic;
using System.Linq;
using BTE.RMS.Common;
using BTE.RMS.Interface.Contract.TaskItem;
using BTE.RMS.Presentation.Logic.Tasks.Model;

namespace BTE.RMS.Presentation.Logic.Tasks.Services
{
    public class TaskService : ITaskService
    {
        #region Fields

        private readonly ITaskRepository taskRepository;

        #endregion

        #region Constructors

        public TaskService(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        #endregion

        #region Public methods

        public void GetAll(Action<List<SummeryTaskItem>, Exception> action)
        {
            try
            {
                var tasks = taskRepository.GetAll();
                var res = tasks.Select(RMSMapper.Map<Task, SummeryTaskItem>).ToList();
                action(res, null);
            }
            catch (Exception e)
            {
                action(default(List<SummeryTaskItem>), e);
            }
        }

        public void GetAllTaskCategory(Action<List<CrudTaskCategory>, Exception> action)
        {
            try
            {
                var taskCategories = taskRepository.GetAllCategories();
                var res = taskCategories.Select(RMSMapper.Map<TaskCategory, CrudTaskCategory>).ToList();
                action(res, null);
            }
            catch (Exception e)
            {
                action(default(List<CrudTaskCategory>), e);
            }
        }

        public void GetAllTaskType(Action<List<TaskTypeDTO>, Exception> action)
        {
            try
            {
                var res=new List<TaskTypeDTO>();
                foreach (var member in Enum.GetValues(typeof (TaskType)))
                {
                    res.Add(new TaskTypeDTO { Id = (int)member, Title = Enum.GetName(typeof(TaskType), member) });
                }
                action(res, null);
            }
            catch (Exception e)
            {
                action(default(List<TaskTypeDTO>), e);
            }

        }

        public void GetBy(Action<CrudTaskItem, Exception> action, long id)
        {
            try
            {
                var task = taskRepository.GetBy(id);
                var res = RMSMapper.Map<Task, CrudTaskItem>(task);
                action(res, null);
            }
            catch (Exception e)
            {
                action(default(CrudTaskItem), e);
            }
        }

        public void CreateTask(Action<CrudTaskItem, Exception> action, CrudTaskItem taskItem)
        {
            try
            {
                var res = CreateTask(taskItem,false);
                action(res, null);
            }
            catch (Exception e)
            {
                action(default(CrudTaskItem), e);
            }
        }

        public void UpdateTask(Action<CrudTaskItem, Exception> action, CrudTaskItem taskItem)
        {
            try
            {
                var res = UpdateTask(taskItem, false);
                action(res, null);
            }
            catch (Exception e)
            {
                action(default(CrudTaskItem), e);
            }
        }

        public void DeleteTask(Action<Exception> action, CrudTaskItem taskItem)
        {
            try
            {
                DeleteTask(taskItem, false);
                action(null);
            }
            catch (Exception e)
            {
                action(e);
            }
        }

        //Sync section

        public CrudTaskItem CreateTask(CrudTaskItem taskItem, bool syncWithServer)
        {
            
            var category = taskRepository.GetCategoryBy(taskItem.CategoryId);
            var task = new Task(taskItem.Title, taskItem.WorkProgressPercent, taskItem.StartDate, taskItem.StartTime,
                taskItem.EndTime, category, (EntityActionType)taskItem.ActionType, taskItem.SyncId, syncWithServer);
            taskRepository.CreatTask(task);
            var res = RMSMapper.Map<Task, CrudTaskItem>(task);
            return res;
        }

        public CrudTaskItem UpdateTask(CrudTaskItem taskItem, bool syncWithServer)
        {
            var category = taskRepository.GetCategoryBy(taskItem.CategoryId);
            var task = syncWithServer ? taskRepository.GetBy(taskItem.SyncId) : taskRepository.GetBy(taskItem.Id);
            task.Update(taskItem.Title, taskItem.StartDate, taskItem.StartTime, taskItem.EndTime,
                taskItem.WorkProgressPercent, category,syncWithServer);
            taskRepository.Update(task);
            var res = RMSMapper.Map<Task, CrudTaskItem>(task);
            return res;
        }

        public void DeleteTask(CrudTaskItem taskItem, bool syncWithServer)
        {
            
            var task = syncWithServer ? taskRepository.GetBy(taskItem.SyncId) : taskRepository.GetBy(taskItem.Id);
            task.Delete(syncWithServer);
            taskRepository.Update(task);
            
        }

        #endregion
    }

}
