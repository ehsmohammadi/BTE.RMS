using System;
using BTE.Presentation;

namespace BTE.RMS.Interface.Contract
{
    public class PrayerTimes : ViewModelBase
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

        private DateTime morningAzanTime;

        public DateTime MorningAzanTime
        {
            get { return morningAzanTime; }
            set { this.SetField(p => p.MorningAzanTime, ref morningAzanTime, value); }
        }

        private DateTime sunRiseTime;

        public DateTime SunRiseTime
        {
            get { return sunRiseTime; }
            set { this.SetField(p => p.SunRiseTime, ref sunRiseTime, value); }
        }
        private DateTime afterNoonAzanTime;

        public DateTime AfterNoonAzanTime
        {
            get { return afterNoonAzanTime; }
            set { this.SetField(p => p.AfterNoonAzanTime, ref afterNoonAzanTime, value); }
        }
        private DateTime sunSetTime;

        public DateTime SunSetTime
        {
            get { return sunSetTime; }
            set { this.SetField(p => p.SunSetTime, ref sunSetTime, value); }
        }

        private DateTime sunSetAzanTime;

        public DateTime SunSetAzanTime
        {
            get { return sunSetAzanTime; }
            set { this.SetField(p=>p.SunSetAzanTime,ref sunSetAzanTime,value);}
        }
    }
}
