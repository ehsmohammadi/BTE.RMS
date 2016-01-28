using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTE.RMS.Presentation.Web.Controllers
{
    public class PatternDesignController : Controller
    {
        //
        // GET: /PatternDesign/
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult SecondaryObjectiveList()
        {
            return View();
        }

        public ActionResult CreateSecondaryObjective()
        {
            return View();
        }
        public ActionResult PersonalPlanning()
        {
            return View();
        }

        public ActionResult ProgramProgress()
        {
            return View();
        }
	}
}