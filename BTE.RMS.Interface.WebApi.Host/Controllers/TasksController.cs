using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BTE.RMS.Interface.Contract.TaskItem;

//using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Interface.WebApi.Host.Controllers
{
    public class TasksController : ApiController
    {

        CrudTaskItem[] overalObjectives = new CrudTaskItem[] 
        { 
            new CrudTaskItem { Id = 1, Title = "Groceries" }, 
            new CrudTaskItem { Id = 2,  Title = "Toys" }, 
            new CrudTaskItem { Id = 3, Title = "Hardware" } 
        };

        public IEnumerable<CrudTaskItem> GetAllProducts()
        {
            return overalObjectives;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = overalObjectives.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
