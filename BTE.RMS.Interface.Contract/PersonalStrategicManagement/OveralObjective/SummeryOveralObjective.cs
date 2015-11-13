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


        private string periority;
        public string Periority
        {
            get { return periority; }
            set { this.SetField(p => p.Periority, ref periority, value); }
        }

    }
}
