using System;
using System.Collections.Generic;
using BTE.RMS.Model.Meetings;

namespace BTE.RMS.Model.Reports
{
    public class MeetingsWithDate
    {
        public DateTime Date { get; set; }

        public List<Meeting> Meetings { get; set; }
    }
}
