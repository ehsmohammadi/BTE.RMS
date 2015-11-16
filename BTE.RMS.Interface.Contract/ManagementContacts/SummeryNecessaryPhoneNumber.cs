using BTE.Presentation;

namespace BTE.RMS.Interface.Contract.ManagementContacts
{
    public class SummeryNecessaryPhoneNumber:NecessaryContactCategory
    {
        private string title;

        public string Title
        {
            get { return title; }
            set { this.SetField(p => p.Title, ref title, value); }
        }

        private long tellNumber;

        public long TellNumber
        {
            get { return tellNumber; }
            set {this.SetField(p=>p.TellNumber,ref tellNumber,value); }
        }
    }
}
