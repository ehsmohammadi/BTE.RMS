using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE.Presentation;

namespace BTE.RMS.Interface.Contract
{
    public class ReceiptAndPayment:ViewModelBase
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { this.SetField(p=>p.Id,ref id,value);}
        }
        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { this.SetField(p=>p.Date,ref date,value);}
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { this.SetField(p=>p.Description,ref description,value);}
        }
        private long amount;

        public long Amount
        {
            get { return amount; }
            set { this.SetField(p => p.Amount, ref amount, value); }
        }

        private TransactionType transactionType;

        public TransactionType TransactionType
        {
            get { return transactionType; }
            set { this.SetField(p => p.TransactionType, ref transactionType, value); }
        }

        private BaseFinancialAccount financialAccount;

        public BaseFinancialAccount FinancialAccount
        {
            get { return financialAccount; }
            set { this.SetField(p=>p.FinancialAccount,ref financialAccount,value);}
        }

        private BaseIncomeTopic incomeTopic;

        public BaseIncomeTopic IncomeTopic
        {
            get { return incomeTopic; }
            set { this.SetField(p=>p.IncomeTopic,ref incomeTopic,value);}
        }

        private BaseCostTopic costTopic;

        public BaseCostTopic CostTopic
        {
            get { return costTopic; }
            set { this.SetField(p=>p.CostTopic,ref costTopic,value);}
        }
    }
}
