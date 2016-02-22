using BTE.RMS.Model.Tasks;
using BTE.RMS.Services.Contract;

namespace BTE.RMS.Services
{
    public class TaskService:ITaskService
    {
        private readonly ITaskRepository taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        public Task CreateTask(CreateTaskCommand taskCommand)
        {
            var category = taskRepository.GetCategoryBy(taskCommand.CategoryId);
            var task = new Task(taskCommand.Title, taskCommand.WorkProgressPercent,
                taskCommand.StartDate, taskCommand.StartTime, taskCommand.EndTime, category,taskCommand.DeviceType);
            taskRepository.CreatTask(task);
            return task;
        }

        public Task UpdateTask(UpdateTaskCommand taskCommand)
        {
            var category = taskRepository.GetCategoryBy(taskCommand.CategoryId);
            var task = taskRepository.GetBy(taskCommand.Id);
            task.Update(taskCommand.Title, taskCommand.StartDate, taskCommand.StartTime, taskCommand.EndTime,
                taskCommand.WorkProgressPercent, category,taskCommand.DeviceType);
            taskRepository.Update(task);
            return task;
        }

        public void Delete(long id)
        {
            taskRepository.DeleteBy(id);

        }
    }
}
