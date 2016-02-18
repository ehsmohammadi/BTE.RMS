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

        public Task CreateTask(CreateTaskCommand createTaskCommand)
        {
            var task = new Task(createTaskCommand.Title, createTaskCommand.WorkProgressPercent,
                createTaskCommand.StartDate, createTaskCommand.StartTime, createTaskCommand.EndTime);
            taskRepository.CreatTask(task);
            return task;
        }
    }
}
