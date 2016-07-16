using System;
using BTE.RMS.Common;

namespace BTE.RMS.Interface.Contract.Reports
{
    public class MeetingReportDto
    {
        #region Meeting

        public MeetingType? MeetingType { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public MeetingStateEnum? State { get;set;}

        public bool WithMinuts { get; set; }

        public bool WithAttachment { get; set; }


        #endregion

    }
}
