using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Interface.WebApi.Host.Controllers
{
    public class OveralObjectiveController : ApiController
    {

        CrudOveralObjective[] overalObjectives = new CrudOveralObjective[] 
        { 
            new CrudOveralObjective { Id = 1, View = "Tomato Soup", AsTarget = "Groceries" }, 
            new CrudOveralObjective { Id = 2, View = "Yo-yo", AsTarget = "Toys" }, 
            new CrudOveralObjective { Id = 3, View = "Hammer", AsTarget = "Hardware" } 
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
