using System;
using BTE.Presentation;

namespace BTE.RMS.Interface.Contract
{
    public class SummeryFinancialAccounts : ViewModelBase
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { this.SetField(p => p.Id, ref  id, value); }
        }

        private string accountTitle;

        public string AccountTitle
        {
            get { return accountTitle; }
            set { this.SetField(p => p.AccountTitle, ref accountTitle, value); }
        }

        private string accountType;

        public string AccountType
        {
            get { return accountType; }
            set { this.SetField(p => p.AccountType, ref accountType, value); }
        }

        private long deposit;

        public long Deposit
        {
            get { return deposit; }
            set { this.SetField(p => p.Deposit, ref deposit, value); }
        }

        private long removal;

        public long Removal
        {
            get { return removal; }
            set
            {
                this.SetField(p => p.Removal, ref removal, value);
            }
        }

        private long cash;

        public long Cash
        {
            get { return cash; }
            set { this.SetField(p=>p.Cash,ref cash,value);}
        }

        private string description;

        public string Description
        {
            get { return description; }
            set
            {
                this.SetField(p=>p.Description,ref description,value);
            }
        }
    }
}
