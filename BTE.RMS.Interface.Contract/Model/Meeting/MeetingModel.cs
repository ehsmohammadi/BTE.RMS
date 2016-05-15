﻿using System;
using System.Collections.Generic;

namespace BTE.RMS.Interface.Contract.Model.Meeting
{
    public class MeetingModel
    {
        public MeetingType MeetingType { get; set; }
        public long Id { get; set; }
        public string Subject { get; set; }
        public DateTime StartDate { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public List<long> Attendees { get; set; }
        public int Duration { get; set; }
    }
}
