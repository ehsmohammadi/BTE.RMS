using System;
using System.Collections.Generic;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers.PersonalFinancialManagement.MaturityAndCzechs
{
    public class FakeMaturityAndChequeServiceWrapper : IMaturityAndChequeServiceWrapper
    {
        private List<Cheque> ExportChequeList = new List<Cheque>
        {
            new Cheque
            {
                Amount = 2000,
                BankBranch = "انصار",
                Purpose = "پرداخت مبلغ",
                State = true
            }
        };
        public void GetAllExportChequeList(Action<List<Cheque>, Exception> action)
        {
            action(ExportChequeList, null);
        }

        private List<Cheque> ReceivedChequeList = new List<Cheque>
        {
            new Cheque
            {
                Amount = 5000,
                BankBranch = "قوامین",
                Purpose = "بروز رسانی اطلاعات",
                State = true
            }
        };
        public void GetAllReceivedChequeList(Action<List<Cheque>, Exception> action)
        {
            action(ReceivedChequeList, null);
        }
        private List<FinancialCommitments> demandList = new List<FinancialCommitments>
        {
            new FinancialCommitments
            {
                Amount = 400000,
                Opponent = "علیرضا محمدی",
                State = true,
                Purpose = "تهیه ابزارات شرکت"
            }
        };
        public void GetAllDemandList(Action<List<FinancialCommitments>, Exception> action)
        {
            action(demandList, null);
        }

        private List<FinancialCommitments> debtList = new List<FinancialCommitments>
        {
            new FinancialCommitments
            {
                Amount = 700000,
                Opponent = "اکبر سلطانی",
                State = false,
                Purpose = "تهیه ابزارات ماشین"
            }
        };
        public void GetAllDebtList(Action<List<FinancialCommitments>, Exception> action)
        {
            action(debtList, null);
        }

        private List<FinancialCommitments> otherCommitmentList = new List<FinancialCommitments>
        {
            new FinancialCommitments
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه"
            },
                        new FinancialCommitments
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه"
            },
                        new FinancialCommitments
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه"
            },
                        new FinancialCommitments
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه"
            },
                        new FinancialCommitments
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه"
            },
                        new FinancialCommitments
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه"
            },
                        new FinancialCommitments
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه"
            },            new FinancialCommitments
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه"
            },
                        new FinancialCommitments
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه"
            },
                        new FinancialCommitments
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه"
            },
                        new FinancialCommitments
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه"
            },
                        new FinancialCommitments
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه"
            },
                        new FinancialCommitments
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه"
            },
                        new FinancialCommitments
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه"
            },

        };

        public void GetAllOtherCommitmentsList(Action<List<FinancialCommitments>, Exception> action)
        {
            action(otherCommitmentList, null);
        }
    }
}
