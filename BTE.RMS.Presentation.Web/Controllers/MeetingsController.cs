using System;
using System.Web.Mvc;
using BTE.RMS.Presentation.Web.ViewModel.Meeting;
using System.Collections.Generic;
using System.Linq;
using BTE.Presentation.Web;
using BTE.RMS.Common;
using System.Globalization;
using System.Text;
using BTE.RMS.Interface.Contract.Meetings;
using BTE.RMS.Presentation.Web.ViewModel.Home;
using System.Web;
using System.IO;
using BTE.RMS.Interface.Contract.Files;
using ImageMagick;

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
        public ActionResult Index(string pdate)
        {

            DateTime dt = new DateTime();
            if (!string.IsNullOrEmpty(pdate))
            {
                dt = GetChristianDateTime(pdate);
            }
            else
            {
                dt = DateTime.Now;
            }
            ViewBag.pdate = dt;

            string Date = "?StartDate=" + dt.ToString("yyyy-MM-dd");
            var meetingListDto = HttpClientHelper.Get<List<MeetingDto>>(apiUri, endpoint + Date);
            var model =
            meetingListDto.OrderBy(p => p.StartDate).Select(md =>
                    new MeetingShowViewModel(md.Id, md.Subject, md.StartDate.Hour, md.StartDate.Minute,
                        md.StartDate.AddHours(md.Duration).ToString("HH:mm"), md.Duration * 60));
            ViewBag.Date = dt.ToString("dd MMMM yyyy");
            ViewBag.PersianYear = ToPersianDigit(new MD.PersianDateTime.PersianDateTime(dt).Year.ToString());
            ViewBag.PersianMonth = new MD.PersianDateTime.PersianDateTime(dt).ToString("MMMM");
            ViewBag.PersianDayOfWeek = ToPersianDigit(new MD.PersianDateTime.PersianDateTime(dt).Day.ToString());
            ViewBag.PersianDay = new MD.PersianDateTime.PersianDateTime(dt).ToString("dddd");



            ViewBag.ArabicDate = ToPersianDigit(dt.ToString("dd MMMM yyyy", new CultureInfo("ar-SA")));
            return View("ShowTimelineMeetings", model);
        }


        public ActionResult YearCalendar()
        {
            return View();
        }

        public ActionResult MonthCalendar()
        {
            return View();
        }

        public ActionResult WeekCalendar()
        {
            return View();
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
            List<FileViewModel> Files = new List<FileViewModel>();
            int i = 0;

            foreach (var item in dto.Files)
            {
                i++;
                Byte[] docbinaryarray = Convert.FromBase64String(item.Content);
                string FileName = "File" + i + item.ContentType;
                string strdocPath = Server.MapPath("/Download/" + FileName);
                FileStream objfilestream = new FileStream(strdocPath, FileMode.Create, FileAccess.ReadWrite);
                objfilestream.Write(docbinaryarray, 0, docbinaryarray.Length);
                objfilestream.Close();
                FileViewModel file = new FileViewModel()
                {
                    FileName = FileName,
                    IsImage = false
                };
                Files.Add(file);
            }
            Session["OldFiles"] = Files;
            return View(meetingModel);
        }

        // POST: Meeting/Modify
        [HttpPost]
        public ActionResult Modify(MeetingViewModel meetingModel)
        {


            if (ModelState.IsValid)
            {
                List<FileDto> FileList = new List<FileDto>();
                if (Session["FileList"] != null)
                {
                    FileList = Session["FileList"] as List<FileDto>;
                }
                if (Session["OldFiles"] != null)
                {
                    var OldFiles = Session["OldFiles"] as List<FileViewModel>;
                    foreach (var item in OldFiles)
                    {
                        string strdocPath = Server.MapPath("/Download/" + item.FileName);
                        FileStream objfilestream = new FileStream(strdocPath, FileMode.Open, FileAccess.Read);
                        int len = (int)objfilestream.Length;
                        Byte[] documentcontents = new Byte[len];
                        objfilestream.Read(documentcontents, 0, len);
                        objfilestream.Close();
                        var str = Convert.ToBase64String(documentcontents);
                        FileDto OldFile = new FileDto()
                        {
                            ContentType = System.IO.Path.GetExtension(item.FileName),
                            Content = str
                        };
                        FileList.Add(OldFile);
                    }
                }
                //foreach (var item in files)
                //{
                //    if (item !=null)
                //    {
                //        MemoryStream target = new MemoryStream();
                //        item.InputStream.CopyTo(target);
                //        byte[] data = target.ToArray();
                //        var str = Convert.ToBase64String(data);
                //        FileDto File = new FileDto()
                //        {
                //            ContentType = System.IO.Path.GetExtension(item.FileName),
                //            Content = str
                //        };
                //        FileList.Add(File);
                //    }
                //}
                var meetingDto = mapToMeetingDto(meetingModel);
                meetingDto.Files = FileList;
                HttpClientHelper.Put(apiUri, endpoint, meetingDto);
                Session.Remove("FileList");
                Session.Remove("OldFiles");

                return RedirectToAction("Index");
            }
            return View(meetingModel);
        }

        public ActionResult SaveUploadedFile()
        {
            bool isSavedSuccessfully = true;
            try
            {
                List<FileDto> FileList = new List<FileDto>();
                if (Session["FileList"] != null)
                {
                    FileList = Session["FileList"] as List<FileDto>;
                }
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    MemoryStream target = new MemoryStream();
                    file.InputStream.CopyTo(target);
                    byte[] data = target.ToArray();
                    try
                    {

                        using (MagickImage image = new MagickImage())
                        {
                            image.Read(target);
                            image.Resize(800, 0);
                            data = image.ToByteArray();
                        }
                    }
                    catch
                    {

                    }

                    var str = Convert.ToBase64String(data);
                    FileDto FileUpload = new FileDto()
                    {
                        ContentType = System.IO.Path.GetExtension(file.FileName),
                        Content = str
                    };
                    //Byte[] docbinaryarray = Convert.FromBase64String(FileUpload.Content);
                    //string strdocPath = "C:\\DocumentDirectory2\\" + file.FileName + FileUpload.ContentType;
                    //FileStream objfilestream = new FileStream(strdocPath, FileMode.Create, FileAccess.ReadWrite);
                    //objfilestream.Write(docbinaryarray, 0, docbinaryarray.Length);
                    //objfilestream.Close();
                    FileList.Add(FileUpload);
                }
                Session["FileList"] = FileList;

            }
            catch (Exception ex)
            {
                isSavedSuccessfully = false;
            }


            if (isSavedSuccessfully)
            {
                return Json(new { Message = "فایل با موفقیت آپلود شد" });
            }
            else
            {
                return Json(new { Message = "خطا در آپلود فایل" });
            }
        }

        [HttpPost]
        public void DeleteFile(string FileName)
        {
            if (Session["OldFiles"] != null)
            {
                var OldFiles = Session["OldFiles"] as List<FileViewModel>;
                foreach (var item in OldFiles)
                {
                    if (item.FileName==FileName)
                    {
                        OldFiles.Remove(item);
                        break;
                    }
                }
                Session["OldFiles"] = OldFiles;
            }
        }

        public ActionResult Detail(long id)
        {
            var dto = HttpClientHelper.Get<MeetingDto>(apiUri, endpoint + "/" + id);
            var meetingModel = mapToViewModel(dto);
            int i = 0;
            List<FileViewModel> Files = new List<FileViewModel>();

            Dictionary<string, int> types = new Dictionary<string, int>();

            types.Add(".png", 1);
            types.Add(".jpg", 1);
            types.Add(".JPG", 1);
            types.Add(".jpeg", 1);

            foreach (var item in dto.Files)
            {

                i++;
                Byte[] docbinaryarray = Convert.FromBase64String(item.Content);
                string FileName = "File" + i + item.ContentType;
                string strdocPath = Server.MapPath("/Download/" + FileName);
                FileStream objfilestream = new FileStream(strdocPath, FileMode.Create, FileAccess.ReadWrite);
                objfilestream.Write(docbinaryarray, 0, docbinaryarray.Length);
                objfilestream.Close();
                FileViewModel file = new FileViewModel()
                {
                    FileName = FileName,
                    IsImage = types.Any(p => p.Key == item.ContentType)

                };
                Files.Add(file);

            }
            Session["OldFiles"] = Files;
            meetingModel.Files = Files;
            return View(meetingModel);
        }



        public string Delete(long id)
        {
            try
            {
                HttpClientHelper.Delete(apiUri, endpoint, id);
                return "1";
            }
            catch (Exception)
            {
                return "0";
            }
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
                Details = meetingModel.Details,
                Decisions = meetingModel.Decisions,
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
                Latitude = dto.LocationLatitude,
                Longitude = dto.LocationLongitude,
                Description = dto.Description,
                Duration = dto.Duration,
                MeetingType = dto.MeetingType,
                StartTime = dto.StartDate.ToString("HH:mm"),
                StartDate = GetPersianDate(dto.StartDate),
                StartDateTime = dto.StartDate,
                Subject = dto.Subject,
                Details = dto.Details,
                Decisions = dto.Decisions,
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

        public string ToPersianDigit(string value)
        {
            var dic = new Dictionary<char, char>
                          {
                              {'0','۰'},
                              {'1','۱'},
                              {'2','۲'},
                              {'3','۳'},
                              {'4','۴'},
                              {'5','۵'},
                              {'6','۶'},
                              {'7','۷'},
                              {'8','۸'},
                              {'9','۹'}
                          };

            return value.Aggregate(string.Empty, (current, chr) => current + (char.IsDigit(chr) ? dic[chr] : chr));
        }


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