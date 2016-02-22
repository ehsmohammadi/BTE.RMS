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

        public IEnumerable<CrudTaskItem> GetAll(SyncReuest syncReuest)
        {
            var tasks = taskService.GetAllUnSync(syncReuest);
            return tasks;
        }

        public IHttpActionResult PostTasks(SyncReuest syncReuest)
        {
            return Ok();
        }


    }
}