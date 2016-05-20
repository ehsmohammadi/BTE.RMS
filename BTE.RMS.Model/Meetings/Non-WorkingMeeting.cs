using System;
using System.Collections.Generic;
using BTE.RMS.Model.Attendees;

namespace BTE.RMS.Model.Meetings
{
    public class NoneWorkingMeeting:Meeting
    {
        protected NoneWorkingMeeting()
        {
            
        }
        public NoneWorkingMeeting(string subject, DateTime startDate, int duration, string description, Location location, List<Attendee> attendees)
            : base(subject, startDate, duration, description, location, attendees)
        {
            
        }
        
    }
}
