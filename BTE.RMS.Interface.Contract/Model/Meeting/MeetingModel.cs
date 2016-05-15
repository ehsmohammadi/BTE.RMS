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
        public LocationModel Location { get; set; }
        public List<AttendeesModel> Attendees { get; set; }
        public TimeSpan Duration { get; set; }

    }
}
