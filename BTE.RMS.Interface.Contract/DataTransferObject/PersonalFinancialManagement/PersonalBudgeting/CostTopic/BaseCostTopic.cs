using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BTE.Presentation;

namespace BTE.RMS.Interface.Contract
{
    public class BaseCostTopic:ViewModelBase
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
        private long monthlyCost;

        public long MonthlyCost
        {
            get { return monthlyCost; }
            set { this.SetField(p => p.MonthlyCost, ref monthlyCost, value); }
        }
    }
}
