using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE.RMS.Presentation.Logic.WPF.PersianDate;

namespace BTE.RMS.Presentation.Logic.Meeting.Model
{
    public class Converter
    {
        public static MeetingDB ConvertToMeetingDb(PrimaryMeeting meeting)
        {
            MeetingDB res = new MeetingDB();
            res.Id = meeting.Id;
            res.Subject = meeting.Subject;
            res.Attendees = meeting.Attendees;
            res.Description = meeting.Details;
            res.Duration = Int32.Parse(meeting.Duration);
            res.StartDate = meeting.Date.ToDateTime();
            return res;
        }

        public static PrimaryMeeting ConvertToPrimaryMeeting(MeetingDB meeting)
        {
            PrimaryMeeting res = new PrimaryMeeting();
            res.Id = meeting.Id;
            res.Subject = meeting.Subject;
            res.Attendees = meeting.Attendees;
            res.Details = meeting.Description;
            res.Duration = meeting.ToString();
            PersianDate date = new PersianDate(meeting.StartDate);
            res.Date = date;
            return res; 
        }
    }
}
