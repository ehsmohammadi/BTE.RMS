using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTE.RMS.Presentation.Logic.Meeting.Model
{
    public class MeetingDB
    {
        public long Id { get; set; }
        public int Type { get; set; }
        public string Subject { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public string Attendees { get; set; }
    }
}
