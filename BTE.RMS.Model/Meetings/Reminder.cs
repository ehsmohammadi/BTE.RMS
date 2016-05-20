using System;
using BTE.RMS.Common;

namespace BTE.RMS.Model.Meetings
{
    public class Reminder
    {
        public Reminder(RepeatingType repeatingType,RemindType remindType, DateTime reminderTime, SeveralTimes severalTimes)
        {
            
        }
        public long Id { get; set; }
        public RepeatingType RepeatingType { get; set; }
        public RemindType RemindTypes { get; set; }
        public DateTime ReminderTime { get; set; }
        public SeveralTimes SeveralTimes { get; set; }
    }
}
