using System;
using System.Web.Mvc;
using BTE.RMS.Presentation.Web.ViewModel.Meeting;
using System.Collections.Generic;
using System.Linq;
using BTE.Presentation.Web;
using BTE.RMS.Common;
using BTE.RMS.Interface.Contract.Model.Meetings;

namespace BTE.RMS.Presentation.Web.Controllers
{
    public class MeetingsController : Controller
    {
        #region Fields
        private readonly string endpoint = "Meetings";
        private readonly Uri apiUri = new Uri(RMSClientConfig.BaseApiAddress);
        #endregion

        #region Methods
        // GET: Meeting
        public ActionResult Index()
        {
            var meetingListDto = HttpClientHelper.Get<List<MeetingDto>>(apiUri, endpoint);
            var model =
            meetingListDto.Select(md =>
                    new MeetingShowViewModel(md.Id, md.Subject, md.StartDate.Hour, md.StartDate.Minute,
                        md.StartDate.AddHours(md.Duration).ToShortTimeString(), md.Duration));
            return View("ShowTimelineMeetings", model);
        }

        public ActionResult Create()
        {

            //initiae param and set to model constructor
            //var meetingModel = new MeetingModel();
            //return View("CreateMeeting", meetingModel);
            return View();
        }

        // POST: Task/Create
        [HttpPost]
        public ActionResult Create(MeetingViewModel meetingModel)
        {
            if (ModelState.IsValid)
            {
                var meetingDto = MapToMeetingDto(meetingModel);
                HttpClientHelper.Post(apiUri, endpoint, meetingDto);                
                return RedirectToAction("Index");
            }
            return View(meetingModel);
        }

        public ActionResult Modify(long id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Modify(MeetingViewModel meetingModel)
        {
            if (ModelState.IsValid)
            {
                //meetingService.Create(meetingModel);
                return RedirectToAction("Index");
            }
            return View(meetingModel);
        }
        #endregion

        #region Private methods
        private MeetingDto MapToMeetingDto(MeetingViewModel meetingModel)
        {
            var meetingDto = new MeetingDto
            {
                Agenda = meetingModel.Agenda,
                Address = meetingModel.Address,
               // Attendees = meetingModel.Attendees.Select(a => a.Id).ToList(),
                Description = meetingModel.Description,
                Duration = meetingModel.Duration,
                Latitude = "0",
                Longitude = "0",
                Subject = meetingModel.Subject,
                MeetingType = (MeetingType)meetingModel.MeetingType,
                StartDate = DateTime.Now,//Convert.ToDateTime(meetingModel.StartDate),
                Reminder = new List<ReminderDto>
                {
                    new ReminderDto
                    {
                        RemindTypes = (RemindType) meetingModel.RemindType,
                        RepeatingType = (RepeatingType) meetingModel.RepeatingType,
                        RemindeTime = meetingModel.RemindeTime
                    }
                }
            };
            return meetingDto;
        } 
        #endregion
    }


}