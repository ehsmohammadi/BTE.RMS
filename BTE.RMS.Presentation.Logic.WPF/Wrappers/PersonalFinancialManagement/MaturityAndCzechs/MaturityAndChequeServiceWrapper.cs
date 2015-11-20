using System;
using System.Collections.Generic;
using System.Linq;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public class FakeMaturityAndChequeServiceWrapper : IMaturityAndChequeServiceWrapper
    {
        private List<SummeryCheque> chequeList = new List<SummeryCheque>
        {
            new SummeryCheque
            {
                Amount = 2000,
                BankBranch = "انصار",
                Purpose = "دریافت مبلغ",
                State = true,
                ChequeType=ChequeType.Received
            },
            new SummeryCheque
            {
                Amount = 5000,
                BankBranch = "صادرات",
                Purpose = "پرداخت مبلغ",
                State = true,
                ChequeType = ChequeType.Payment
            }
        };
        public void GetAllPaymentChequeList(Action<List<SummeryCheque>, Exception> action)
        {
            action(chequeList.Where(e => e.ChequeType == ChequeType.Payment).ToList(), null);
        }

        public void GetAllReceivedChequeList(Action<List<SummeryCheque>, Exception> action)
        {
            action(chequeList.Where(e => e.ChequeType == ChequeType.Received).ToList(), null);

        }
        private List<SummeryFinancialCommitments> financialCommitmentsList = new List<SummeryFinancialCommitments>
        {
            new SummeryFinancialCommitments
            {
                Amount = 400000,
                Opponent = "علیرضا محمدی",
                State = true,
                Purpose = "تهیه ابزارات شرکت",
                FinancialCommitmentsType = FinancialCommitmentsType.Demand
            },
            new SummeryFinancialCommitments
            {
                Amount = 700000,
                Opponent = "اکبر سلطانی",
                State = false,
                Purpose = "تهیه ابزارات ماشین",
                FinancialCommitmentsType = FinancialCommitmentsType.Debt
            },
            new SummeryFinancialCommitments
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه",
                FinancialCommitmentsType = FinancialCommitmentsType.OtherCommitments
            },
                        new SummeryFinancialCommitments
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه",
                FinancialCommitmentsType = FinancialCommitmentsType.OtherCommitments
            },
        };
        public void GetAllDemandList(Action<List<SummeryFinancialCommitments>, Exception> action)
        {
            action(financialCommitmentsList.Where(e=>e.FinancialCommitmentsType==FinancialCommitmentsType.Demand).ToList(),null);
        }

        public void GetAllDebtList(Action<List<SummeryFinancialCommitments>, Exception> action)
        {
            action(financialCommitmentsList.Where(e=>e.FinancialCommitmentsType==FinancialCommitmentsType.Debt).ToList(),null);
        }

        public void GetAllOtherCommitmentsList(Action<List<SummeryFinancialCommitments>, Exception> action)
        {
            action(financialCommitmentsList.Where(e=>e.FinancialCommitmentsType==FinancialCommitmentsType.OtherCommitments).ToList(),null);
        }


    }
}
