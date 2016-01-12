using System;
using System.Collections.Generic;
using System.Globalization;
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
        
        public ActionResult Index()
        {
            var vm = new TodayVM();
            return View(vm);
        }

        public ActionResult EducationalSubject()
        {
            return View();
        }

        public ActionResult Planing(string date)
        {
           
            if (string.IsNullOrEmpty(date))
                Bootstrapper.SelectedDate = DateTime.Now;
            else
            {
                var d = PersianDateTime.Parse(date);
                Bootstrapper.SelectedDate = d.ToDateTime();
            }

            var vm = new PlanningVM(Bootstrapper.SelectedDate);
            return View(vm);
        }

        public ActionResult Backend()
        {
            return new Dpc(Bootstrapper.SelectedDate).CallBack(this);
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
            BusinessBeginsHour = 8;
            BusinessEndsHour = 6;
            Culture=new CultureInfo("fa-IR");
            Events = TasksController.taskItems.Where(t=>t.StartDate.Date==startDateTime.Date);

            DataIdField = "Id";
            DataTextField = "Title";
            DataStartField = "StartTime";
            DataEndField = "EndTime";

            Update();
        }
    }
}