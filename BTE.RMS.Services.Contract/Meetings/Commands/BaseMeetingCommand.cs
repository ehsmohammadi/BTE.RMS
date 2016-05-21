using System;
using System.Collections.Generic;
using BTE.RMS.Model.Attendees;
using BTE.RMS.Model.Meetings;
using BTE.RMS.Services.Contract.Meetings.Commands;

namespace BTE.RMS.Services.Contract.Meetings
{
    public class BaseMeetingCommand
    {
        public string Subject { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }
        public List<long> Attendees { get; set; }
        public List<CreateReminderCommand> Reminder { get; set; }
        public String Agenda { get; set; }
        public DateTime NextMeeting { get; set; }
        public int Progress { get; set; }
        public int Priority { get; set; }
        public int StateId { get; set; }
        //public List<> MeetingOwner { get; set; }
        public bool HaveApprovalAccess { get; set; }

     }
}
