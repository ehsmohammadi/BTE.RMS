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
            throw new NotImplementedException();
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