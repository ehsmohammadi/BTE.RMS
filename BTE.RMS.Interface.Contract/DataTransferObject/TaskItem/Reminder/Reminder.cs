using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE.Presentation;

namespace BTE.RMS.Interface.Contract
{
    public class Reminder:ViewModelBase
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { this.SetField(p => p.Id, ref id, value); }
        }

        private TaskReminderType taskReminderType;

        public TaskReminderType TaskReminderType
        {
            get { return taskReminderType; }
            set { this.SetField(p => p.TaskReminderType, ref taskReminderType, value); }
        }

        private DateTime reminderTime;

        public DateTime ReminderTime
        {
            get { return reminderTime; }
            set { this.SetField(p => p.ReminderTime, ref reminderTime, value); }
        }
        private DateTime reminderStartDate;

        public DateTime ReminderStartDate
        {
            get { return reminderStartDate; }
            set { this.SetField(p => p.ReminderStartDate, ref reminderStartDate, value); }
        }
        private DateTime reminderEndDate;

        public DateTime ReminderEndDate
        {
            get { return reminderEndDate; }
            set { this.SetField(p => p.ReminderEndDate, ref reminderEndDate, value); }
        }

        private int reminderPerDay;

        public int ReminderPerDay
        {
            get { return reminderPerDay; }
            set { this.SetField(p => p.ReminderPerDay, ref reminderPerDay, value); }
        }

        private int reminderDuration;

        public int ReminderDuration
        {
            get { return reminderDuration; }
            set { this.SetField(p => p.ReminderDuration, ref reminderDuration, value); }
        }
    }
}
