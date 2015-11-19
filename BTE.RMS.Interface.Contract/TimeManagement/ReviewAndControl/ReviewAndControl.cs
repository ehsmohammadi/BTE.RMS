using System;
using BTE.Presentation;

namespace BTE.RMS.Interface.Contract
{
    public class ReviewAndControl:ViewModelBase
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
            set { this.SetField(p=>p.Title,ref title,value);}
        }

        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { this.SetField(p=>p.Date,ref date,value);}
        }

        private DateTime startTime;

        public DateTime StartTime
        {
            get { return startTime; }
            set { this.SetField(p=>p.StartTime,ref startTime,value);}
        }
        private DateTime endTime;

        public DateTime EndTime
        {
            get { return endTime; }
            set { this.SetField(p => p.EndTime, ref endTime, value); }
        }

        private string state;

        public string State
        {
            get { return state; }
            set { this.SetField(p=>p.State,ref state,value);}
        }

        private string category;

        public string Category
        {
            get { return category; }
            set { this.SetField(p=>p.Category,ref category,value);}
        }
    }
}
