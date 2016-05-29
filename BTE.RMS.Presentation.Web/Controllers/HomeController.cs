using System;
using System.Web.Mvc;
using BTE.RMS.Presentation.Web.ViewModel.Home;
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

        //public ActionResult Backend()
        //{
        //    //var taskByDate = taskService.GetTaskByStartDate(Bootstrapper.SelectedDate);
        //    return new Dpc(taskByDate).CallBack(this);
        //}

    }

    //class Dpc : DayPilotCalendar
    //{
    //    private readonly List<SummeryTaskItem> taskByDate;
    //    public Dpc(List<SummeryTaskItem> taskByDate)
    //    {
    //        this.taskByDate = taskByDate;
    //    }

    //    protected override void OnInit(InitArgs e)
    //    {
    //        StartDate = Bootstrapper.SelectedDate;
    //        BusinessBeginsHour = 8;
    //        BusinessEndsHour = 6;
    //        Culture=new CultureInfo("fa-IR");
    //        Events = taskByDate;

    //        DataIdField = "Id";
    //        DataTextField = "Title";
    //        DataStartField = "StartTime";
    //        DataEndField = "EndTime";

    //        Update();
    //    }
    //}
}