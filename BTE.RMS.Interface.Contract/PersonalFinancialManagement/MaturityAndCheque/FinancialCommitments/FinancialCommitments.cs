using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE.Presentation;

namespace BTE.RMS.Interface.Contract
{
    public class FinancialCommitments : BaseMaturityAndCheque
    {
        private string opponent;

        public string Opponent
        {
            get { return opponent; }
            set { this.SetField(p => p.Opponent, ref opponent, value); }
        }
        private FinancialCommitmentsType financialCommitmentsType;

        public FinancialCommitmentsType FinancialCommitmentsType
        {
            get { return financialCommitmentsType; }
            set { this.SetField(p => p.FinancialCommitmentsType, ref financialCommitmentsType, value); }
        }
    }
}
