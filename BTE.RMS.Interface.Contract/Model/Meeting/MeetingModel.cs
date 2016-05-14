using BTE.RMS.Interface.Contract.Model.Attendees;
using BTE.RMS.Interface.Contract.Model.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTE.RMS.Interface.Contract.Model.Meeting
{
    public class MeetingModel
    {
        public long Id { get; set; }
        public string Subject { get; set; }
        public DateTime StartDate { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Attendees { get; set; }
        public int Duration { get; set; }
    }
}
