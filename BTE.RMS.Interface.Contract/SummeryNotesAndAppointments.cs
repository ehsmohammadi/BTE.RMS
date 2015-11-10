using System;
using BTE.Presentation;

namespace BTE.RMS.Interface.Contract
{
    public class SummeryNoteAndAppointment : ViewModelBase
    {

        #region Public
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
            set { this.SetField(p => p.Title, ref  title, value); }
        }


        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set
            {
                this.SetField(p => p.Date, ref date, value);
                Datestr = date.ToShortDateString();
            }

        }


        private string datestr;
        public string Datestr
        {
            get { return datestr; }
            set { this.SetField(p => p.Datestr, ref datestr, value); }
        }


        private DateTime startTime;
        public DateTime StartTime
        {
            get { return startTime; }
            set
            {
                this.SetField(p => p.StartTime, ref startTime, value);
                StartTimestr = startTime.ToShortTimeString();
            }
        }


        private string startTimestr;
        public string StartTimestr
        {
            get { return startTimestr; }
            set { this.SetField(p => p.StartTimestr, ref startTimestr, value); }
        }


        private DateTime endTime;

        public DateTime EndTime
        {
            get { return endTime; }
            set
            {
                this.SetField(p => p.EndTime, ref endTime, value);
                EndTimestr = endTime.ToShortTimeString();
            }
        }


        private string endTimestr;

        public string EndTimestr
        {
            get { return endTimestr; }
            set
            {
                this.SetField(p => p.EndTimestr, ref endTimestr, value);
            }
        }


        private int percentRun;

        public int PercentRun
        {
            get { return percentRun; }
            set { this.SetField(p => p.PercentRun, ref percentRun, value); }
        }


        private string category;
        public string Category
        {
            get { return category; }
            set
            {
                this.SetField(p => p.Category, ref category, value);
            }
        } 
        #endregion
    }
}
