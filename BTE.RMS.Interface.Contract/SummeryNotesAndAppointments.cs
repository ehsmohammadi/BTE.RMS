using System;
using BTE.Presentation;

namespace BTE.RMS.Interface.Contract
{
    public class SummeryNotesAndAppointments : ViewModelBase
    {
        #region private
        private long id;
        private string title;
        private DateTime date;
        private string datestr;
        private DateTime startTime;
        private string startTimestr;
        private DateTime endTime;
        private string endTimestr;
        private int percentRun;
        private string category;
        #endregion

        #region Public
        public long Id
        {
            get { return id; }
            set { this.SetField(p => p.Id, ref id, value); }
        }



        public string Title
        {
            get { return title; }
            set { this.SetField(p => p.Title, ref  title, value); }
        }



        public DateTime Date
        {
            get { return date; }
            set
            {
                this.SetField(p => p.Date, ref date, value);
                Datestr = date.ToShortDateString();
            }

        }



        public string Datestr
        {
            get { return datestr; }
            set { this.SetField(p => p.Datestr, ref datestr, value); }
        }



        public DateTime StartTime
        {
            get { return startTime; }
            set
            {
                this.SetField(p => p.StartTime, ref startTime, value);
                StartTimestr = startTime.ToShortTimeString();
            }
        }



        public string StartTimestr
        {
            get { return startTimestr; }
            set { this.SetField(p => p.StartTimestr, ref startTimestr, value); }
        }



        public DateTime EndTime
        {
            get { return endTime; }
            set
            {
                this.SetField(p => p.EndTime, ref endTime, value);
                EndTimestr = endTime.ToShortTimeString();
            }
        }



        public string EndTimestr
        {
            get { return endTimestr; }
            set
            {
                this.SetField(p => p.EndTimestr, ref endTimestr, value);
            }
        }



        public int PercentRun
        {
            get { return percentRun; }
            set { this.SetField(p => p.PercentRun, ref percentRun, value); }
        }



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
