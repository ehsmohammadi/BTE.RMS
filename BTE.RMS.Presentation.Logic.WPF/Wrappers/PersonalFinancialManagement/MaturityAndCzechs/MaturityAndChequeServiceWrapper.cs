using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public class FakeMaturityAndChequeServiceWrapper : IMaturityAndChequeServiceWrapper
    {
        private List<Cheque> chequeList = new List<Cheque>
        {
            new Cheque
            {
                Amount = 20000,
                BankBranch = "صادرات",
                ChequeType = ChequeType.Payment,
                Description = "بابت هزینه های شرکت",
                Id = 1000,
                State = false,
                
            },
            new Cheque
            {
                Amount = 400000,
                BankBranch = "انصار",
                ChequeType = ChequeType.Received,
                Description = "طلب از شرکت ایران نت",
                Id = 1001,
                State = true,
               
            }
        }; 
        private List<FinancialCommitments> financialCommitmentsList=new List<FinancialCommitments>
        {
            new FinancialCommitments
            {
                Amount = 20000,
                Description = "طلب از شرکت",
                FinancialCommitmentsType = FinancialCommitmentsType.Demand,
                Id = 1000,
                State = true,
                Opponent = "شرکت",
            },
                        new FinancialCommitments
            {
                Amount = 20000,
                Description = "بدهی  شرکت",
                FinancialCommitmentsType = FinancialCommitmentsType.Debt,
                Id = 1001,
                State = false,
                Opponent = "شرکت",
            },
                                    new FinancialCommitments
            {
                Amount = 40000,
                Description = "قرض الحسنه  شرکت",
                FinancialCommitmentsType = FinancialCommitmentsType.OtherCommitments,
                Id = 1002,
                State = true,
                Opponent = "شرکت",
            },

        }; 
        public void GetAllPaymentChequeList(Action<List<Cheque>, Exception> action)
        {
            action(chequeList.Where(e => e.ChequeType == ChequeType.Payment).ToList(), null);
        }

        public void GetAllReceivedChequeList(Action<List<Cheque>, Exception> action)
        {
            action(chequeList.Where(e => e.ChequeType == ChequeType.Received).ToList(), null);

        }
        public void GetAllDemandList(Action<List<FinancialCommitments>, Exception> action)
        {
            action(financialCommitmentsList.Where(e => e.FinancialCommitmentsType == FinancialCommitmentsType.Demand).ToList(), null);
        }

        public void GetAllDebtList(Action<List<FinancialCommitments>, Exception> action)
        {
            action(financialCommitmentsList.Where(e => e.FinancialCommitmentsType == FinancialCommitmentsType.Debt).ToList(), null);
        }

        public void GetAllOtherCommitmentsList(Action<List<FinancialCommitments>, Exception> action)
        {
            action(financialCommitmentsList.Where(e => e.FinancialCommitmentsType == FinancialCommitmentsType.OtherCommitments).ToList(), null);
        }


    }
}
