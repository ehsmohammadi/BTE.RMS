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
                                    Location location,string attendeesName, string agenda, Guid syncId, AppType appType,User creator)
            : base(subject,startDate,duration,description,location,attendeesName,agenda,syncId,appType,creator)
        {
            
        }

        public void Update(string subject, DateTime startDate, int duration, string description,
             string attendeesName,Location location, string agenda, AppType appType)
        {
            base.Update(subject,startDate,duration,description,location,attendeesName,agenda,appType);
        }
    }
}
