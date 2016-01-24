using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE.Presentation;

namespace BTE.RMS.Interface.Contract
{
    public class SummeryIncomeTopic : BaseIncomeTopic
    {
        private long yearlyIncome;

        public long YearlyIncome
        {
            get { return yearlyIncome; }
            set { this.SetField(p => p.YearlyIncome, ref yearlyIncome, value); }
        }
    }
}
