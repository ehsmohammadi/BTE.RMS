using System;

namespace BTE.RMS.Interface.Contract.Web.TaskItem
{
    public class TaskItem
    {

        public long Id { get; set; }

        public string Title { get; set; }

        public TaskItemType TaskItemType { get; set; }

        public TaskCategory TaskCategory { get; set; }

        public int WorkProgressPercent { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Content { get; set; }

        #region Remider Property

        public ReminderType ReminderType { get; set; }

        public DateTime ReminderTime { get; set; }

        public DateTime EndDate { get; set; }

        public int ReminderPerDay { get; set; }

        public int ReminderDuration { get; set; } 

        #endregion

    }
}
