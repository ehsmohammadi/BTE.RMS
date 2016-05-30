using System;
using BTE.RMS.Common;
using BTE.RMS.Model.Users;

namespace BTE.RMS.Model.Meetings
{
    public class NoneWorkingMeeting:Meeting
    {
        protected NoneWorkingMeeting()
        {
        }

        public NoneWorkingMeeting(
                                    string subject, 
                                    DateTime startDate, 
                                    int duration, 
                                    string description,
                                    Location location, string attendeesName, string agenda, Guid syncId, AppType appType, User creator)
            : base(subject, startDate, duration, description, location, attendeesName, agenda, syncId, appType, creator)
        {
            
        }


        public void Update(string subject, DateTime startDate, string description,
    int duration, AppType appType, string attendeesName, string agenda)
        {
            Subject = subject;
            StartDate = startDate;
            Description = description;
            Duration = duration;
            AttendeesName = attendeesName;
            Agenda = agenda;
        }
    }
}
