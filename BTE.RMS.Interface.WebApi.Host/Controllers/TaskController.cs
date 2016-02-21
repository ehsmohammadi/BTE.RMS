using System.Collections.Generic;
using System.Web.Http;
using BTE.RMS.Interface.Contract.Facade;
using BTE.RMS.Interface.Contract.TaskItem;


namespace BTE.RMS.Interface.WebApi.Host.Controllers
{
    public class TaskController : ApiController
    {
        private readonly ITaskFacadeService taskService;

        public TaskController(ITaskFacadeService taskService)
        {
            this.taskService = taskService;
        }

        public IEnumerable<SummeryTaskItem> GetAll()
        {
            var tasks = taskService.GetAll();
            return tasks;
        }

        public IHttpActionResult GetProduct(long id)
        {
            var task = taskService.Get(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }


    }
}
