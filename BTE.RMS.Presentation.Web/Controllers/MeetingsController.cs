using BTE.RMS.Interface.Contract.Model.Meeting;
using BTE.RMS.Interface.Contract.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return View("_Layout");
        }

        public ActionResult Create()
        {
            //initiae param and set to model constructor
            var meetingModel = new MeetingModel();
            return View("CreateMeeting", meetingModel);
        }

        // POST: Task/Create
        [HttpPost]
        public ActionResult Create(MeetingModel meetingModel)
        {
            if (ModelState.IsValid)
            {
                meetingService.Create(meetingModel);
                return RedirectToAction("Index");
            }
            return View("CreateMeeting", meetingModel);
        }

    }
}