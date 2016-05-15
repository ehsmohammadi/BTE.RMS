using System;
using System.Collections.Generic;
using BTE.RMS.Model.Attendees;
using BTE.RMS.Model.Meetings;

namespace BTE.RMS.Services.Contract.Meetings
{
    public class BaseMeetingCommand
    {
        public string Subject { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }
        public List<long> Attendees { get; set; }

     }
}
