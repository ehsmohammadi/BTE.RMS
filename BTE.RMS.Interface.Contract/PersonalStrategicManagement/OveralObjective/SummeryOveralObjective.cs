using System.Text.RegularExpressions;
using BTE.Presentation;

namespace BTE.RMS.Interface.Contract
{
    public class SummeryOveralObjective : ViewModelBase
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
            set { this.SetField(p => p.Title, ref title, value); }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { this.SetField(p => p.Description, ref description, value); }
        }

        private PeriorityType periorityType;

        public PeriorityType PeriorityType
        {
            get { return periorityType; }
            set { this.SetField(p=>p.PeriorityType,ref periorityType,value);}
        }
    }
}
