using System;
using BTE.Presentation;

namespace BTE.RMS.Interface.Contract.PersonalStrategicManagement.SecondaryObjectives
{
    public class SummerySecondaryObjective:ViewModelBase
    {
        private long id;
        public long Id
        {
            get { return id; }
            set { this.SetField(p => p.Id, ref id, value); }
        }
        private string periority;

        public string Periority
        {
            get { return periority; }
            set { this.SetField(p=>p.Periority,ref periority,value);}
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { this.SetField(p=>p.Title,ref title,value);}
        }

        private string overalObjective;

        public string OveralObjective
        {
            get { return overalObjective; }
            set { this.SetField(p=>p.OveralObjective,ref overalObjective,value);}
        }

        private DateTime startDate;

        public DateTime StartDate
        {
            get { return startDate; }
            set { this.SetField(p=>p.StartDate,ref startDate,value);}
        }

        private DateTime endDate;

        public DateTime EndDate
        {
            get { return endDate; }
            set { this.SetField(p=>p.EndDate,ref endDate,value);}
        }
    }
}
