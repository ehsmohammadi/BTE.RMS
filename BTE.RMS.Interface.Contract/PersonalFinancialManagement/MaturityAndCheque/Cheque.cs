using System;
using BTE.Presentation;

namespace BTE.RMS.Interface.Contract.PersonalFinancialManagement.MaturityAndCzech
{
    public class Cheque : ViewModelBase
    {
        private long id;
        public long Id
        {
            get { return id; }
            set { this.SetField(p => p.Id, ref id, value); }
        }
        private DateTime maturityDate;

        public DateTime MaturityDate
        {
            get { return maturityDate; }
            set { this.SetField(p => p.MaturityDate, ref maturityDate, value); }
        }

        private string bankBranch;

        public string BankBranch
        {
            get { return bankBranch; }
            set { this.SetField(p => p.BankBranch, ref bankBranch, value); }
        }

        private long amount;

        public long Amount
        {
            get { return amount; }
            set { this.SetField(p => p.Amount, ref amount, value); }
        }

        private string purpose;

        public string Purpose
        {
            get { return purpose; }
            set { this.SetField(p => p.Purpose, ref purpose, value); }
        }

        private Boolean state;

        public Boolean State
        {
            get { return state; }
            set { this.SetField(p => p.State, ref state, value); }
        }
    }
}
