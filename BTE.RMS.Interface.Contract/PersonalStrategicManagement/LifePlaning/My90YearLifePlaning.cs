using System.Net.Sockets;
using BTE.Presentation;

namespace BTE.RMS.Interface.Contract.PersonalStrategicManagement.LifePlaning
{
    public class My90YearLifePlaning:ViewModelBase
    {
        private long id;
        public long Id
        {
            get { return id; }
            set { this.SetField(p => p.Id, ref id, value); }
        }
        private string spendingType;

        public string SpendingType
        {
            get { return spendingType; }
            set { this.SetField(p=>p.SpendingType,ref spendingType,value);}
        }

        private long inNightDay_Hour;

        public long InNightDay_Hour
        {
            get { return inNightDay_Hour; }
            set { this.SetField(p=>p.InNightDay_Hour,ref inNightDay_Hour,value);}
        }

        private long inLife_Year;

        public long InLife_Year
        {
            get { return inLife_Year; }
            set { this.SetField(p=>p.InLife_Year,ref inLife_Year,value);}
        }

        private double percent;

        public double Percent
        {
            get { return percent; }
            set { this.SetField(p=>p.Percent,ref percent,value);}
        }
        private long inNightDay_Hour2;

        public long InNightDay_Hour2
        {
            get { return inNightDay_Hour2; }
            set { this.SetField(p => p.InNightDay_Hour2, ref inNightDay_Hour2, value); }
        }

        private long inLife_Year2;

        public long InLife_Year2
        {
            get { return inLife_Year2; }
            set { this.SetField(p => p.InLife_Year2, ref inLife_Year2, value); }
        }

        private long inOverLife_Year;

        public long InOverLife_Year
        {
            get { return inOverLife_Year; }
            set { this.SetField(p=>p.InOverLife_Year,ref inOverLife_Year,value);}
        }
        private double percent2;
        public double Percent2
        {
            get { return percent2; }
            set { this.SetField(p => p.Percent2, ref percent2, value); }
        }
    }
}
