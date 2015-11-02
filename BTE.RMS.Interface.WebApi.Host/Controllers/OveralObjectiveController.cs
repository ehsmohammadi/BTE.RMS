using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Interface.WebApi.Host.Controllers
{
    public class OveralObjectiveController : ApiController
    {

        CrudOveralObjective[] overalObjectives = new CrudOveralObjective[] 
        { 
            new CrudOveralObjective { Id = 1, Overview = "Tomato Soup", Title = "Groceries" }, 
            new CrudOveralObjective { Id = 2, Overview = "Yo-yo", Title = "Toys" }, 
            new CrudOveralObjective { Id = 3, Overview = "Hammer", Title = "Hardware" } 
        };

        public IEnumerable<CrudOveralObjective> GetAllProducts()
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
