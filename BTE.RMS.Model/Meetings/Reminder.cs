using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BTE.RMS.Common;

namespace BTE.RMS.Model.Meetings
{
    public class Reminder
    {

        #region Properties

        [Key,ForeignKey("Meeting")]
        public long Id { get; set; }
        public RepeatingType RepeatingType { get; set; }
        public ReminderType ReminderType { get; set; }
        public int CustomReminderTime { get; set; }
        public ReminderTimeType ReminderTimeType { get; set; }

        public Meeting Meeting { get; set; }


        #endregion

        #region Constructors
        protected Reminder()
        {

        }

        public Reminder(ReminderType reminderType, ReminderTimeType reminderTimeType, RepeatingType repeatingType, int customReminderTime = 0)
        {
            RepeatingType = repeatingType;
            ReminderType = reminderType;
            CustomReminderTime = customReminderTime;
            ReminderTimeType = reminderTimeType;
        } 
        #endregion

    }
}
