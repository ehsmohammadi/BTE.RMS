using BTE.Presentation;

namespace BTE.RMS.Interface.Contract
{
    public class BaseFinancialAccount:ViewModelBase
    {
        private long id;
        public long Id
        {
            get { return id; }
            set { this.SetField(p => p.Id, ref id, value); }
        }
        private string accountTitle;

        public string AccountTitle
        {
            get { return accountTitle; }
            set { this.SetField(p => p.AccountTitle, ref accountTitle, value); }
        }

        private AccountType accountType;

        public AccountType AccountType
        {
            get { return accountType; }
            set { this.SetField(p=>p.AccountType,ref accountType,value);}
        }
        private string description;

        public string Description
        {
            get { return description; }
            set
            {
                this.SetField(p => p.Description, ref description, value);
            }
        }
    }
}
