using BTE.Presentation;

namespace BTE.RMS.Interface.Contract.PersonalStrategicManagement.LifePlaning
{
    public class HumanTimeInLife:ViewModelBase
    {
        private long id;
        public long Id
        {
            get { return id; }
            set { this.SetField(p => p.Id, ref id, value); }
        }
        private string time;

        public string Time
        {
            get { return time; }
            set { this.SetField(p=>p.Time,ref time,value);}
        }

        private long allOfLife;

        public long AllOfLife
        {
            get { return allOfLife; }
            set { this.SetField(p=>p.AllOfLife,ref allOfLife,value);}
        }

        private long passedLife;

        public long PassedLife
        {
            get { return passedLife; }
            set { this.SetField(p=>p.PassedLife,ref passedLife,value);}
        }

        private long overLife;

        public long OverLife
        {
            get { return overLife; }
            set { this.SetField(p=>p.OverLife,ref overLife,value);}
        }
    }
}
