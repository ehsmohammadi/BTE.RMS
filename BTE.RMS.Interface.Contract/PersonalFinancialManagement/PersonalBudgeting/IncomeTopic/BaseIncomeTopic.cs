using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE.Presentation;


namespace BTE.RMS.Interface.Contract
{
    public class BaseIncomeTopic:ViewModelBase
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { this.SetField(p => p.Id, ref id, value); }
        }
        private string title;

        public string Title
        {
            get { return title; }
            set { this.SetField(p => p.Title, ref title, value); }
        }
        private long monthlyIncome;

        public long MonthlyIncome
        {
            get { return monthlyIncome; }
            set { this.SetField(p => p.MonthlyIncome, ref monthlyIncome, value); }
        }
    }
}
