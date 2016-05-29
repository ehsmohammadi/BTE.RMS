using System;
using BTE.RMS.Common;

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
                                    Location location, Guid syncId, AppType appType)
            : base(subject, startDate, duration, description, location,syncId,appType)
        {
            
        }
        
    }
}
