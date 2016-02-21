using System;
using System.Collections.Generic;
using System.Web.Http;
using BTE.RMS.Interface.Contract.Facade;
using BTE.RMS.Interface.Contract.TaskItem;
using BTE.RMS.Model.Tasks;


namespace BTE.RMS.Interface.WebApi.Host.Controllers
{
    public class TaskController : ApiController
    {
        private readonly ITaskFacadeService taskService;

        public TaskController(ITaskFacadeService taskService)
        {
            this.taskService = taskService;
        }

        public IEnumerable<CrudTaskItem> GetAll()
        {
            var tasks = new List<CrudTaskItem>
            {
                new CrudTaskItem
                {
                    Id = 1,
                    CategoryId = 1,
                    Title = "برگه خرید",
                    TaskItemType = TaskItemType.Note,
                    EndTime = DateTime.Now,
                    StartDate = DateTime.Now,
                    StartTime = DateTime.Now,
                    WorkProgressPercent = 33,
                    Content = "jlsdkfjlksdjlksdf"
                    
                },
                new CrudTaskItem
                {
                    Id = 1,
                    CategoryId = 1,
                    Title = "برگه فروش",
                    TaskItemType = TaskItemType.Note,
                    EndTime = DateTime.Now,
                    StartDate = DateTime.Now,
                    StartTime = DateTime.Now,
                    WorkProgressPercent = 33,
                    Content = "jlsdkfjlksdjlksdf"
                    
                }

            };
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
