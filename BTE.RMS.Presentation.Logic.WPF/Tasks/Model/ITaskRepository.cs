using System;
using System.Collections.Generic;
using BTE.Core;

namespace BTE.RMS.Presentation.Logic.Tasks.Model
{
    public interface ITaskRepository:IRepository
    {
        IEnumerable<Task> GetAll();
        IEnumerable<TaskCategory> GetAllCategories();


        void CreatTask(Task task);
        void Update(Task task);
        void CreatTaskCategory(TaskCategory taskCategory);
        Task GetBy(long id);
        TaskCategory GetCategoryBy(long id);


        IEnumerable<Task> GetAllUnsync();
        Task GetBy(Guid syncId);
    }
}
