using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE.Presentation;

namespace BTE.RMS.Interface.Contract
{
    public class SummeryCostTopic : BaseCostTopic
    {
        private long yearlyCost;

        public long YearlyCost
        {
            get { return yearlyCost; }
            set { this.SetField(p => p.YearlyCost, ref yearlyCost, value); }
        }
    }
}
