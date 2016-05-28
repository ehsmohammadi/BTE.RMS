using System;
using BTE.RMS.Common;

namespace BTE.RMS.Interface.Contract.Model.Meetings
{
    public class ReminderDto
    {
        public long Id { get; set; }
        public RepeatingType RepeatingType { get; set; }
        public RemindType RemindTypes { get; set; }
        public DateTime RemindeTime { get; set; }
        public SeveralTimes SeveralTimes { get; set; }
    }
}
