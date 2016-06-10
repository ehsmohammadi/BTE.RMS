using System;
using BTE.RMS.Common;

namespace BTE.RMS.Interface.Contract.Model.Meetings
{
    public class ReminderDto
    {
        public long Id { get; set; }
        public RepeatingType RepeatingType { get; set; }
        public ReminderType ReminderType { get; set; }
        public int CustomReminderTime { get; set; }
        public ReminderTimeType ReminderTimeType { get; set; }
    }
}
