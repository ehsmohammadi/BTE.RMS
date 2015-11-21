using BTE.Presentation;

namespace BTE.RMS.Interface.Contract
{
    public class CrudDailyShortTip:DailyShortTip
    {
        private string title;

        public string Title
        {
            get { return title; }
            set { this.SetField(p=>p.Title,ref title,value);}
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { this.SetField(p=>p.Description,ref description,value);}
        }
    }
}
