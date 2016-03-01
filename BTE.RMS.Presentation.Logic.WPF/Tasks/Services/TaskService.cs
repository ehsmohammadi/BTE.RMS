using System;
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
                var taskTypes = taskRepository.GetAllTaskTypes();
                var res = taskTypes.Select(RMSMapper.Map<TaskType, TaskTypeDTO>).ToList();
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
                var category = taskRepository.GetCategoryBy(taskItem.CategoryId);
                var task = new Task(taskItem.Title, taskItem.WorkProgressPercent, taskItem.StartDate.Value, taskItem.StartTime,
                    taskItem.EndTime, category, EntityActionType.Create);
                taskRepository.CreatTask(task);
                var res = RMSMapper.Map<Task, CrudTaskItem>(task);
                action(res, null);
            }
            catch (Exception e)
            {
                action(default(CrudTaskItem), e);
            }
        } 

        #endregion
    }

}
