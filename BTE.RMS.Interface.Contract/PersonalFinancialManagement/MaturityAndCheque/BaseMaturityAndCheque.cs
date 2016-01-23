using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE.Presentation;

namespace BTE.RMS.Interface.Contract
{
    public class BaseMaturityAndCheque:ViewModelBase
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
        private long amount;

        public long Amount
        {
            get { return amount; }
            set { this.SetField(p => p.Amount, ref amount, value); }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set { this.SetField(p => p.Description, ref description, value); }
        }
        private Boolean state;

        public Boolean State
        {
            get { return state; }
            set { this.SetField(p=>p.State,ref state,value);}
        }
    }
}
