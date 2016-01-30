using System;
using BTE.Presentation;

namespace BTE.RMS.Interface.Contract
{
    public class CrudSecondaryObjective : SummerySecondaryObjective
    {
        private string timeObjective;

        public string TimeObjective
        {
            get { return timeObjective; }
            set { this.SetField(p=>p.timeObjective,ref timeObjective,value);}
        }

        private DateTime deadLine;

        public DateTime DeadLine
        {
            get { return deadLine; }
            set { this.SetField(p=>p.DeadLine,ref  deadLine,value);}
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { this.SetField(p => p.Description,ref description,value); }
        }

        private string mission;

        public string Mission
        {
            get { return mission; }
            set { this.SetField(p=>p.Mission,ref mission,value);}
        }
    }
}
