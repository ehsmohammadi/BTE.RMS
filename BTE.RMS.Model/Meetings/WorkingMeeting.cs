using System;
using System.Collections.Generic;
using BTE.RMS.Common;
using BTE.RMS.Model.Attendees;
using BTE.RMS.Model.Meetings.MeetingStates;
using BTE.RMS.Model.Users;

namespace BTE.RMS.Model.Meetings
{
    public class WorkingMeeting:Meeting
    {
        protected WorkingMeeting()
        {

        }
        public WorkingMeeting(string subject, 
                                    DateTime startDate, 
                                    int duration, 
                                    string description,
                                    Location location, Guid syncId, AppType appType)
            : base(subject,startDate,duration,description,location,syncId,appType)
        {
            
        }
    }
}
