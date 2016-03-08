using BTE.RMS.Common;
using BTE.RMS.Model.Tasks;
using BTE.RMS.Services.Contract;
using BTE.RMS.Services.Contract.Tasks;

namespace BTE.RMS.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        public Task CreateTask(CreateTaskCommand taskCommand)
        {
            var category = taskRepository.GetCategoryBy(taskCommand.CategoryId);
            var task = new Task(taskCommand.Title, taskCommand.StartDate, taskCommand.StartTime, taskCommand.EndTime,
                taskCommand.Content, taskCommand.WorkProgressPercent, category, taskCommand.AppType, taskCommand.SyncId);
            taskRepository.CreatTask(task);
            return task;
        }

        public Task UpdateTask(UpdateTaskCommand taskCommand)
        {
            var category = taskRepository.GetCategoryBy(taskCommand.CategoryId);

            //todo: Bad Code here, check what can we do in this situation 
            Task task;
            if (taskCommand.AppType == AppType.AndriodApp || taskCommand.AppType == AppType.DesktopApp)
                task = taskRepository.GetBy(taskCommand.SyncId);
            else
                task = taskRepository.GetBy(taskCommand.Id);
            task.Update(taskCommand.Title, taskCommand.StartDate, taskCommand.StartTime, taskCommand.EndTime, taskCommand.Content,
                taskCommand.WorkProgressPercent, category, taskCommand.AppType);
            taskRepository.Update(task);
            return task;
        }

        public void DeleteTask(DeleteTaskCommand taskCommand)
        {
            Task task;
            if (taskCommand.AppType == AppType.AndriodApp || taskCommand.AppType == AppType.DesktopApp)
                task = taskRepository.GetBy(taskCommand.SyncId);
            else
                task = taskRepository.GetBy(taskCommand.Id);
            task.Delete(taskCommand.AppType);
            taskRepository.Update(task);
        }


    }
}
