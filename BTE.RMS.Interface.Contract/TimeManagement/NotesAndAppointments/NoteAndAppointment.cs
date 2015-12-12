using System;
using BTE.Presentation;

namespace BTE.RMS.Interface.Contract
{
    public class NoteAndAppointment : Category
    {
        private string title;
        public string Title
        {
            get { return title; }
            set { this.SetField(p => p.Title, ref  title, value); }
        }


        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set
            {
                this.SetField(p => p.Date, ref date, value);
            }

        }
        private DateTime startTime;
        public DateTime StartTime
        {
            get { return startTime; }
            set
            {
                this.SetField(p => p.StartTime, ref startTime, value);
            }
        }

        private DateTime endTime;

        public DateTime EndTime
        {
            get { return endTime; }
            set
            {
                this.SetField(p => p.EndTime, ref endTime, value);
            }
        }


        private int percentRun;

        public int PercentRun
        {
            get { return percentRun; }
            set { this.SetField(p => p.PercentRun, ref percentRun, value); }
        }

        private RecordType recordType;

        public RecordType RecordType
        {
            get { return recordType; }
            set { this.SetField(p=>p.RecordType,ref recordType,value);}
        }
    }
}
