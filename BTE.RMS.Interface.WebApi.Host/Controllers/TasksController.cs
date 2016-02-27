using System.Collections.Generic;
using System.Web.Http;
using BTE.RMS.Interface.Contract.DataTransferObject.TaskItem.Sync;
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
        public IHttpActionResult PostTasks(SyncReuest syncReuest)
        {
            taskService.CreateTasks(syncReuest);
            return Ok();
        }


    }
}