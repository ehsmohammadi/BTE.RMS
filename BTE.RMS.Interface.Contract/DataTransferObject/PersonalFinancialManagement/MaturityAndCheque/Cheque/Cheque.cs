using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE.Presentation;

namespace BTE.RMS.Interface.Contract
{
    public class Cheque : BaseMaturityAndCheque
    {
        private string bankBranch;

        public string BankBranch
        {
            get { return bankBranch; }
            set { this.SetField(p => p.BankBranch, ref bankBranch, value); }
        }
        private ChequeType chequeType;

        public ChequeType ChequeType
        {
            get { return chequeType; }
            set { this.SetField(p => p.ChequeType, ref chequeType, value); }
        }
    }
}
