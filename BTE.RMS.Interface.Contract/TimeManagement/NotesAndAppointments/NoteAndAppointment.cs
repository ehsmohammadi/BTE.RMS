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

        private int workProgressPercent;

        public int WorkProgressPercent
        {
            get { return workProgressPercent; }
            set { this.SetField(p => p.WorkProgressPercent, ref workProgressPercent, value); }
        }

        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { this.SetField(p => p.Date, ref date, value); }
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

        private Reminder reminder;

        public Reminder Reminder
        {
            get { return reminder; }
            set { this.SetField(p=>p.Reminder,ref reminder,value);}
        }

        private RecordType recordType;

        public RecordType RecordType
        {
            get { return recordType; }
            set { this.SetField(p=>p.RecordType,ref recordType,value);}
        }

        private NoteAndAppointmentCategory category;

        public NoteAndAppointmentCategory Category
        {
            get { return category; }
            set { this.SetField(p=>p.Category,ref category,value);}
        }
    }
}
