using BTE.RMS.Interface.Contract.Model.Meeting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTE.RMS.Presentation.Web.Controllers
{
    public class MeetingController : Controller
    {
        private readonly IMeetingFacadeService meetingService;

        public MeetingController(IMeetingFacadeService meetingService)
        {
            this.meetingService = meetingService;
        }

        // GET: Meeting
        public ActionResult Index()
        {
            var viewModel = new MeetingModel();
            viewModel.Load(meetingService);
            return View("Meetinglist", viewModel);
        }
    }
}