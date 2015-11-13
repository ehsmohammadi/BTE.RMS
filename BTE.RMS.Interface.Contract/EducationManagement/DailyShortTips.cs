using System;
using BTE.Presentation;

namespace BTE.RMS.Interface.Contract.EducationManagement
{
    public class DailyShortTips:ViewModelBase
    {
        private long id;
        public long Id
        {
            get { return id; }
            set { this.SetField(p => p.Id, ref id, value); }
        }
        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { this.SetField(p => p.Date, ref date, value); }
        }

        private string reSource;

        public string ReSource
        {
            get { return reSource; }
            set
            {
                this.SetField(p => p.ReSource, ref reSource, value);
            }
        }

        private string text;

        public string Text
        {
            get { return text; }
            set { this.SetField(p => p.Text, ref text, value); }
        }
    }
}
