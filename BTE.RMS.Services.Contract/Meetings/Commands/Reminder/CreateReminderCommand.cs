using BTE.RMS.Common;

namespace BTE.RMS.Services.Contract.Meetings
{
    public class CreateReminderCommand
    {
        public RepeatingType RepeatingType { get; set; }
        public ReminderType ReminderType { get; set; }
        public int CustomReminderTime { get; set; }
        public ReminderTimeType ReminderTimeType { get; set; }
    }
}
