using System;
using System.Collections.Generic;
using BTE.RMS.Common;
using BTE.RMS.Interface.Contract.Files;
using BTE.RMS.Interface.Contract.Model;

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

        public MeetingStateEnum State { get;set;}


        #endregion

        #region Reminder
        public ReminderDto Reminder { get; set; } 
        #endregion

        //todo : this is not what i think fuck it 
        public string Details { get; set; }

        public string Decisions { get; set; }

        public IList<FileDto> Files { get; set; } 

    }
}
