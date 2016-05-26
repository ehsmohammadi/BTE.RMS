using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTE.RMS.Presentation.Web.ViewModel.Meeting
{
    public class MeetingShowViewModel
    {
        public long Id { get; set; }
        public string Subject { get; set; }
        public int StartTimeHour { get; set; }
        public int StartTimeminute { get; set; }
        public string EndTime { get; set; }
        public int Duration { get; set; }


    }
}