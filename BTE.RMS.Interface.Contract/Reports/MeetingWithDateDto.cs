using System;
using System.Collections.Generic;
using BTE.RMS.Common;
using BTE.RMS.Interface.Contract.Meetings;

namespace BTE.RMS.Interface.Contract.Reports
{
    public class MeetingWithDateDto
    {

        public DateTime Date { get; set; }

        public List<MeetingDto> Meetings { get; set; }


    }
}
