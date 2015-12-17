using System;
using BTE.Presentation;
using Microsoft.Build.Framework.XamlTypes;

namespace BTE.RMS.Interface.Contract
{
    public class NoteAndAppointment : ViewModelBase
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { this.SetField(p => p.Id, ref id, value); }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { this.SetField(p => p.Title, ref title, value); }
        }

        private Category category;

        public Category Category
        {
            get { return category; }
            set { this.SetField(p => p.Category, ref category, value); }
        }

        private RecordCategory recordCategory;

        public RecordCategory RecordCategory
        {
            get { return recordCategory; }
            set { this.SetField(p=>p.RecordCategory,ref recordCategory,value);}
        }
        private int workProgressPercent;

        public int WorkProgressPercent
        {
            get { return workProgressPercent; }
            set { this.SetField(p => p.WorkProgressPercent, ref workProgressPercent, value); }
        }

        private DateTime startDate;

        public DateTime StartDate
        {
            get { return startDate; }
            set { this.SetField(p => p.StartDate, ref startDate, value); }
        }

        private DateTime startTime;

        public DateTime StartTime
        {
            get { return startTime; }
            set { this.SetField(p => p.StartTime, ref startTime, value); }
        }

        private DateTime endTime;

        public DateTime EndTime
        {
            get { return endTime; }
            set { this.SetField(p => p.EndTime, ref endTime, value); }
        }

        #region Reminder Property

        private ReminderType reminderType;

        public ReminderType ReminderType
        {
            get { return reminderType; }
            set { this.SetField(p => p.ReminderType, ref reminderType, value); }
        }

        private DateTime reminderDate;

        public DateTime ReminderDate
        {
            get { return reminderDate; }
            set { this.SetField(p=>p.ReminderDate,ref reminderDate,value);}
        }

        private DateTime reminderTime;

        public DateTime ReminderTime
        {
            get { return reminderTime; }
            set { this.SetField(p=>p.ReminderTime,ref reminderTime,value);}
        }

        private DateTime reminderEndDate;

        public DateTime ReminderEndDate
        {
            get { return reminderEndDate; }
            set { this.SetField(p=>p.ReminderEndDate,ref reminderEndDate,value);}
        }

        private int reminderPerDay;

        public int ReminderPerDay
        {
            get { return reminderPerDay; }
            set { this.SetField(p=>p.ReminderPerDay,ref reminderPerDay,value);}
        }

        private int reminderDuration;

        public int ReminderDuration
        {
            get { return reminderDuration; }
            set { this.SetField(p=>p.ReminderDuration,ref reminderDuration,value);}
        }

        #endregion

    }
}
