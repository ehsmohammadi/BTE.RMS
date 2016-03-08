using System.Collections.Generic;
using System.Web.Http;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Interface.Contract.Facade;
using BTE.RMS.Interface.Contract.TaskItem;


namespace BTE.RMS.Interface.WebApi.Host.Controllers
{
    public class TaskSyncController : ApiController
    {
        private readonly ITaskFacadeService taskService;

        public TaskSyncController(ITaskFacadeService taskService)
        {
            this.taskService = taskService;
        }

        [HttpGet]
        public IEnumerable<CrudTaskItem> GetAll(int deviceType)
        {
            var tasks = taskService.GetAllUnSync(deviceType);
            return tasks;
        }

        [HttpPost]
        public IHttpActionResult PostTasks(TaskSyncRequest syncReuest)
        {
            taskService.SyncTasks(syncReuest);
            return Ok();
        }

        public IHttpActionResult PostTaskCategories(TaskCategorySyncRequest syncRequest)
        {
            taskService.SyncTaskCategories(syncRequest);
            return Ok();
        }


    }
}