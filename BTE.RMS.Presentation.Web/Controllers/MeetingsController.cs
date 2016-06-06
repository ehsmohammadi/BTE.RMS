using System;
using System.Web.Mvc;
using BTE.RMS.Presentation.Web.ViewModel.Meeting;
using System.Collections.Generic;
using System.Linq;
using BTE.Presentation.Web;
using BTE.RMS.Common;
using BTE.RMS.Interface.Contract.Model.Meetings;
using System.Globalization;
using System.Text;
using BTE.RMS.Interface.Contract.Meetings;
using BTE.RMS.Presentation.Web.ViewModel.Home;

namespace BTE.RMS.Presentation.Web.Controllers
{
    [Authorize]
    public class MeetingsController : Controller
    {
        #region Fields
        private readonly string endpoint = "Meetings";
        private readonly Uri apiUri = new Uri(WebApiClientConfig.WebApiUrl);
        #endregion

        #region Methods
        // GET: Meeting
        public ActionResult Index()
        {
            var meetingListDto = HttpClientHelper.Get<List<MeetingDto>>(apiUri, endpoint);
            var model =
            meetingListDto.Select(md =>
                    new MeetingShowViewModel(md.Id, md.Subject, md.StartDate.Hour, md.StartDate.Minute,
                        md.StartDate.AddHours(md.Duration).ToString("HH:mm"), md.Duration * 60));
            var vm = new TodayVM();
            ViewBag.Date = vm.Date;
            ViewBag.PersianDate = vm.PersianDate;
            ViewBag.ArabicDate = vm.ArabicDate;
            return View("ShowTimelineMeetings", model);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Meeting/Create
        [HttpPost]
        public ActionResult Create(MeetingViewModel meetingModel)
        {
            if (ModelState.IsValid)
            {
                var meetingDto = mapToMeetingDto(meetingModel);
                HttpClientHelper.Post(apiUri, endpoint, meetingDto);
                return RedirectToAction("Index");
            }
            return View(meetingModel);
        }

        public ActionResult Modify(long id)
        {
            var dto = HttpClientHelper.Get<MeetingDto>(apiUri, endpoint + "/" + id);
            var meetingModel = mapToViewModel(dto);
            return View(meetingModel);
        }

        // POST: Meeting/Modify
        [HttpPost]
        public ActionResult Modify(MeetingViewModel meetingModel)
        {
            if (ModelState.IsValid)
            {
                var meetingDto = mapToMeetingDto(meetingModel);
                HttpClientHelper.Put(apiUri, endpoint, meetingDto);
                return RedirectToAction("Index");
            }
            return View(meetingModel);
        }

        public ActionResult Detail(long id)
        {
            var dto = HttpClientHelper.Get<MeetingDto>(apiUri, endpoint + "/" + id);
            var meetingModel = mapToViewModel(dto);
            return View(meetingModel);
        }

        #endregion

        #region Private methods
        private MeetingDto mapToMeetingDto(MeetingViewModel meetingModel)
        {
            string datetime = ConvertDigitsToLatin(meetingModel.StartDate) + "/" + meetingModel.StartTime + "/0";
            var meetingDto = new MeetingDto
            {
                Id = meetingModel.Id,
                Agenda = meetingModel.Agenda,
                LocationAddress = meetingModel.Address,
                Attendees = meetingModel.AttendeesList,
                Description = meetingModel.Description,
                Duration = meetingModel.Duration,
                LocationLatitude = meetingModel.Latitude,
                LocationLongitude = meetingModel.Longitude,
                Subject = meetingModel.Subject,
                MeetingType = meetingModel.MeetingType,
                StartDate = GetChristianDateTime(datetime),
                Reminder = new ReminderDto
                {
                    ReminderType = (ReminderType)meetingModel.ReminderType,
                    RepeatingType = (RepeatingType)meetingModel.RepeatingType,
                    ReminderTimeType = (ReminderTimeType)meetingModel.ReminderTime
                }
            };
            return meetingDto;
        }

        private MeetingViewModel mapToViewModel(MeetingDto dto)
        {
            var meetingModel = new MeetingViewModel
            {
                Id = dto.Id,
                Address = dto.LocationAddress,
                Agenda = dto.Agenda,
                AttendeesList = dto.Attendees,
                Description = dto.Description,
                Duration = dto.Duration,
                MeetingType = dto.MeetingType,
                StartTime = dto.StartDate.ToString("HH:mm"),
                StartDate = GetPersianDate(dto.StartDate),
                Subject = dto.Subject,
                ReminderTime = dto.Reminder != null ? (int)dto.Reminder.ReminderTimeType : 0,
                ReminderType = dto.Reminder != null ? (int)dto.Reminder.ReminderType : 0,
                RepeatingType = dto.Reminder != null ? (int)dto.Reminder.RepeatingType : 0,
            };
            return meetingModel;
        }
        #endregion

        #region ConvertDigitsToLatin
        public string ConvertDigitsToLatin(string s)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    //Persian digits
                    case '\u06f0':
                        sb.Append('0');
                        break;
                    case '\u06f1':
                        sb.Append('1');
                        break;
                    case '\u06f2':
                        sb.Append('2');
                        break;
                    case '\u06f3':
                        sb.Append('3');
                        break;
                    case '\u06f4':
                        sb.Append('4');
                        break;
                    case '\u06f5':
                        sb.Append('5');
                        break;
                    case '\u06f6':
                        sb.Append('6');
                        break;
                    case '\u06f7':
                        sb.Append('7');
                        break;
                    case '\u06f8':
                        sb.Append('8');
                        break;
                    case '\u06f9':
                        sb.Append('9');
                        break;

                    //Arabic digits    
                    case '\u0660':
                        sb.Append('0');
                        break;
                    case '\u0661':
                        sb.Append('1');
                        break;
                    case '\u0662':
                        sb.Append('2');
                        break;
                    case '\u0663':
                        sb.Append('3');
                        break;
                    case '\u0664':
                        sb.Append('4');
                        break;
                    case '\u0665':
                        sb.Append('5');
                        break;
                    case '\u0666':
                        sb.Append('6');
                        break;
                    case '\u0667':
                        sb.Append('7');
                        break;
                    case '\u0668':
                        sb.Append('8');
                        break;
                    case '\u0669':
                        sb.Append('9');
                        break;
                    default:
                        sb.Append(s[i]);
                        break;
                }
            }
            return sb.ToString();
        }
        #endregion

        #region GetChristianDateTime
        public static DateTime GetChristianDateTime(string _Fdate)
        {
            _Fdate = _Fdate.Trim().Replace(':', '/').Replace('-', '/').Replace(' ', '/');
            var dateArray = new string[6];
            if (_Fdate.Length <= 10)
            {
                _Fdate = _Fdate + "/0/0/0";
            }
            dateArray = _Fdate.Split('/');

            PersianCalendar pcalendar = new PersianCalendar();
            GregorianCalendar gcalendar = new GregorianCalendar();
            DateTime eDate = pcalendar.ToDateTime(
                    gcalendar.GetYear(new DateTime(int.Parse(dateArray[0]), 1, 1)),
                    gcalendar.GetMonth(new DateTime(1395, int.Parse(dateArray[1]), 1)),
                    gcalendar.GetDayOfMonth(new DateTime(1395, 1, int.Parse(dateArray[2]))),
                    gcalendar.GetHour(new DateTime(1395, 1, 1, int.Parse(dateArray[3]), 0, 0)),
                    gcalendar.GetMinute(new DateTime(1395, 1, 1, 1, int.Parse(dateArray[4]), 0)),
                    gcalendar.GetSecond(new DateTime(1395, 1, 1, 1, 1, int.Parse(dateArray[5]))), 0);
            return eDate;
        }
        #endregion


        public string GetPersianDate(DateTime dateTimeParam)
        {
            PersianCalendar persianCalendar = new PersianCalendar();

            string year = persianCalendar.GetYear(dateTimeParam).ToString();
            string month = persianCalendar.GetMonth(dateTimeParam).ToString("00");
            string day = persianCalendar.GetDayOfMonth(dateTimeParam).ToString("00");

            return string.Format("{0:0000}/{1:00}/{2:00}", year, month, day);

        }



    }


}