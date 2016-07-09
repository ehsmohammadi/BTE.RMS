using System;
using BTE.RMS.Common;

namespace BTE.RMS.Interface.Contract.Meetings
{
    public class MeetingHistoryDto
    {
        public long Id { get; set; }
        public MeetingOperationEnum Operation { get; set; }
        public DateTime OperationDate { get; set; } 
    }
}
