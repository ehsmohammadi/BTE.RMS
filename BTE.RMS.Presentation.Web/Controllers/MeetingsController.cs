using BTE.RMS.Interface.Contract.Facade;
using System;
using System.Web.Mvc;
using BTE.RMS.Presentation.Web.ViewModel.Meeting;
using System.Collections.Generic;

namespace BTE.RMS.Presentation.Web.Controllers
{
    public class MeetingsController : Controller
    {
        private readonly IMeetingFacadeService meetingService;

        public MeetingsController(IMeetingFacadeService meetingService)
        {
            this.meetingService = meetingService;
        }

        // GET: Meeting
        public ActionResult Index()
        {
            var meetingList = meetingService.GetAll();
            var viewModel = new MeetingListModel {MeetingList = meetingList};
            return View("MeetingList", viewModel);
        }

        public ActionResult ShowMeeting()
        {
            List<MeetingShowViewModel> model = new List<MeetingShowViewModel>();
            MeetingShowViewModel m1 = new MeetingShowViewModel()
            {
                Id = 1,
                Subject = "موضوع",
                StartTimeHour=10,
                StartTimeminute=30,
                EndTime="12:00",
                Duration=90
            };
            MeetingShowViewModel m2 = new MeetingShowViewModel()
            {
                Id = 1,
                Subject = "موضوع",
                StartTimeHour = 13,
                StartTimeminute=00,
                EndTime = "16:20",
                Duration = 200
            };
            MeetingShowViewModel m3 = new MeetingShowViewModel()
            {
                Id = 1,
                Subject = "موضوع",
                StartTimeHour = 00,
                StartTimeminute = 00,
                EndTime = "04:00",
                Duration = 240
            };
            MeetingShowViewModel m4 = new MeetingShowViewModel()
            {
                Id = 1,
                Subject = "موضوع",
                StartTimeHour = 05,
                StartTimeminute = 23,
                EndTime = "08:23",
                Duration = 180
            };
            MeetingShowViewModel m5 = new MeetingShowViewModel()
            {
                Id = 1,
                Subject = "موضوع",
                StartTimeHour = 10,
                StartTimeminute = 00,
                EndTime = "11:55",
                Duration = 115
            };
            MeetingShowViewModel m6 = new MeetingShowViewModel()
            {
                Id = 1,
                Subject = "موضوع",
                StartTimeHour = 12,
                StartTimeminute = 00,
                EndTime = "14:20",
                Duration = 140
            };
            MeetingShowViewModel m7 = new MeetingShowViewModel()
            {
                Id = 1,
                Subject = "موضوع",
                StartTimeHour = 17,
                StartTimeminute = 30,
                EndTime = "19:30",
                Duration = 120
            };
            MeetingShowViewModel m8 = new MeetingShowViewModel()
            {
                Id = 1,
                Subject = "موضوع",
                StartTimeHour = 20,
                StartTimeminute = 00,
                EndTime = "24:00",
                Duration = 240
            };
            model.Add(m1);
            model.Add(m2);
            model.Add(m3);
            model.Add(m4);
            model.Add(m5);
            model.Add(m6);
            model.Add(m7);
            model.Add(m8);

            return View(model);
        }

        public ActionResult Create()
        {

            //initiae param and set to model constructor
            //var meetingModel = new MeetingModel();
            //return View("CreateMeeting", meetingModel);
            return View("CreateMeeting");
        }

        // POST: Task/Create
        [HttpPost]
        public ActionResult Create(MeetingViewModel meetingModel)
        {
            if (ModelState.IsValid)
            {
                //meetingService.Create(meetingModel);
                return RedirectToAction("Index");
            }
            return View("CreateMeeting", meetingModel);
        }

        public ActionResult Edit(long id)
        {
            return View();
        }

        public ActionResult Details(long id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Delete(long id)
        {
            throw new NotImplementedException();
        }
    }
}