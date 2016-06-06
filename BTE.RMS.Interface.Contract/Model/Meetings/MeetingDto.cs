using System;
using BTE.RMS.Interface.Contract.Model.Meetings;

namespace BTE.RMS.Interface.Contract.Meetings
{
    public class MeetingDto
    {
        #region Meeting
        public int MeetingType { get; set; }
        public long Id { get; set; }
        public string Subject { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public string LocationAddress { get; set; }
        public double LocationLatitude { get; set; }
        public double LocationLongitude { get; set; }
        public string Attendees { get; set; }
        public string Description { get; set; }
        public String Agenda { get; set; } 
        #endregion

        #region Reminder
        public ReminderDto Reminder { get; set; } 
        #endregion

    }
}
