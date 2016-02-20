using BTE.Core;
using BTE.RMS.Model.Tasks;

namespace BTE.RMS.Services.Contract
{
    public interface ITaskService:IService
    {
        Task CreateTask(CreateTaskCommand createTaskCommand);
        Task UpdateTask(UpdateTaskCommand taskCommand);
        void Delete(long id);
    }
}
