using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTE.RMS.Presentation.Web.ViewModel.Meeting
{
    public class MeetingShowViewModel
    {

        #region Properties
        public long Id { get; set; }
        public string Subject { get; set; }
        public int StartTimeHour { get; set; }
        public int StartTimeminute { get; set; }
        public string EndTime { get; set; }
        public int Duration { get; set; } 
        #endregion

        #region Constructor
        public MeetingShowViewModel(long id, string subject, int startTimeHour, int startTimeminute, string endTime, int duration)
        {
            Id = id;
            Subject = subject;
            StartTimeHour = startTimeHour;
            StartTimeminute = startTimeminute;
            EndTime = endTime;
            Duration = duration;
        } 
        #endregion

    }
}