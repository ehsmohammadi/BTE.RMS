using BTE.Core;
using BTE.RMS.Model.Tasks;
using BTE.RMS.Services.Contract.Tasks;

namespace BTE.RMS.Services.Contract
{
    public interface ITaskService:IService
    {
        Task CreateTask(CreateTaskCommand createTaskCommand);
        Task UpdateTask(UpdateTaskCommand taskCommand);
        void DeleteTask(DeleteTaskCommand taskCommand);
    }
}
