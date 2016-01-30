using System;
using BTE.Presentation;

namespace BTE.RMS.Interface.Contract
{
    public class SummerySecondaryObjective:ViewModelBase
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

        private SummeryOveralObjective overalObjective;

        public SummeryOveralObjective OveralObjective
        {
            get { return overalObjective; }
            set { this.SetField(p=>p.OveralObjective,ref overalObjective,value);}
        }
    }
}
