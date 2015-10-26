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

        OveralObjective[] overalObjectives = new OveralObjective[] 
        { 
            new OveralObjective { Id = 1, View = "Tomato Soup", AsTarget = "Groceries" }, 
            new OveralObjective { Id = 2, View = "Yo-yo", AsTarget = "Toys" }, 
            new OveralObjective { Id = 3, View = "Hammer", AsTarget = "Hardware" } 
        };

        public IEnumerable<OveralObjective> GetAllProducts()
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
