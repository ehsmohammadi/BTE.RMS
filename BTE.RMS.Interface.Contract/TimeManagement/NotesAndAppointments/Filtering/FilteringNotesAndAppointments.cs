using BTE.Presentation;

namespace BTE.RMS.Interface.Contract
{
    public class FilteringNotesAndAppointments : WorkspaceViewModel
    {
        private long id;
        public long Id
        {
            get { return id; }
            set { this.SetField(p => p.Id, ref id, value); }
        }
        private string filter;

        public string Filter
        {
            get { return filter; }
            set { this.SetField(p => p.Filter, ref filter, value); }
        }

    }
}
