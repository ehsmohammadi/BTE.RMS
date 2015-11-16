using System;
using BTE.Presentation;

namespace BTE.RMS.Interface.Contract
{
    public class RegisterReceiptAndPayment : ViewModelBase
    {
        private long id;
        public long Id
        {
            get { return id; }
            set { this.SetField(p => p.Id, ref id, value); }
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

        private string accountTitle;

        public string AccountTitle
        {
            get { return accountTitle; }
            set { this.SetField(p=>p.AccountTitle,ref accountTitle,value);}
        }

        private string topic;

        public string Topic
        {
            get { return topic; }
            set { this.SetField(p=>p.Topic,ref  topic,value);}
        }

        private long amount;

        public long Amount
        {
            get { return amount; }
            set { this.SetField(p=>p.Amount,ref amount,value);}
        }
    }
}
