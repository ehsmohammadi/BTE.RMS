using System;
using System.Collections.Generic;
using BTE.Core;

namespace BTE.RMS.Presentation.Logic.Tasks.Model
{
    public interface ITaskRepository:IRepository
    {
        void CreatTask(Task task);
        void CreatTaskCategory(TaskCategory taskCategory);
        IEnumerable<Task> GetAll();
        IEnumerable<TaskCategory> GetAllCategories();
        Task GetBy(long id);
        TaskCategory GetCategoryBy(long id);
        void DeleteBy(long id);
        void Update(Task task);
        IEnumerable<Task> GetAllUnsync();
        List<Task> GetTaskByStartDate(DateTime starDate);
        List<TaskType> GetAllTaskTypes();
    }
}
