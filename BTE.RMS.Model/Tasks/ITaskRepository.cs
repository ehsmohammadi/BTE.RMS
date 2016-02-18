using BTE.Core;

namespace BTE.RMS.Model.Tasks
{
    public interface ITaskRepository:IRepository
    {
        void CreatTask(Task task);
        void CreatTaskCategory(TaskCategory taskCategory);
    }
}
