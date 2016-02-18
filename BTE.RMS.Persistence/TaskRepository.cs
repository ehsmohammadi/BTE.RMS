using BTE.RMS.Model.Tasks;

namespace BTE.RMS.Persistence
{
    public class TaskRepository:ITaskRepository
    {
        public void CreatTask(Task task)
        {
            using (var ctx=new RMSContext())
            {
                ctx.Tasks.Add(task);
                ctx.SaveChanges();
            }
        }

        public void CreatTaskCategory(TaskCategory taskCategory)
        {
            throw new System.NotImplementedException();
        }
    }
}
