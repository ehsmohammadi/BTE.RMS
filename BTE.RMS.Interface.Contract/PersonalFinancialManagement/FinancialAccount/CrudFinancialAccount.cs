using BTE.Presentation;

namespace BTE.RMS.Interface.Contract
{
    public class CrudFinancialAccount:BaseFinancialAccount
    {
        private long accountNumber;

        public long AccountNumber
        {
            get { return accountNumber; }
            set { this.SetField(p=>p.AccountNumber,ref accountNumber,value);}
        }

        private string bankBranch;

        public string BankBranch
        {
            get { return bankBranch; }
            set { this.SetField(p=>p.BankBranch,ref bankBranch,value);}
        }
    }
}
