using BTE.Presentation;

namespace BTE.RMS.Interface.Contract
{
    public class BTE_DTO: ViewModelBase
    {
        private long id;
        public long Id
        {
            get { return id; }
            set { this.SetField(p => p.Id, ref id, value); }
        }
    }
}
