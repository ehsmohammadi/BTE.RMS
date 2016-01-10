using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTE.RMS.Presentation.Web.ViewModel.Home;
using DayPilot.Web.Mvc;
using DayPilot.Web.Mvc.Events.Calendar;
using MD.PersianDateTime;


namespace BTE.RMS.Presentation.Web.Controllers
{
    public class HomeController : Controller
    {
        DateTime selectedDate;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EducationalSubject()
        {
            return View();
        }

        public ActionResult Planing(string date)
        {
           
            if (string.IsNullOrEmpty(date))
                selectedDate = DateTime.Now;
            else
            {
                var d = PersianDateTime.Parse(date);
                selectedDate = d.ToDateTime();
            }

            var vm = new PlanningVM(selectedDate);
            return View(vm);
        }

        public ActionResult Backend()
        {
            return new Dpc(selectedDate).CallBack(this);
        }

    }

    class Dpc : DayPilotCalendar
    {
        private readonly DateTime startDateTime;

        public Dpc(DateTime startDateTime)
        {
            this.startDateTime = startDateTime;
        }

        protected override void OnInit(InitArgs e)
        {
            StartDate = startDateTime;
            //var db = new DataClasses1DataContext();
            //Events = from ev in db.events select ev;

            //DataIdField = "id";
            //DataTextField = "text";
            //DataStartField = "eventstart";
            //DataEndField = "eventend";

            Update();
        }
    }
}