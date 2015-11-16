using System;
using System.Collections.Generic;
using BTE.RMS.Interface.Contract.PersonalFinancialManagement.MaturityAndCzech;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers.PersonalFinancialManagement.MaturityAndCzechs
{
    public class FakeMaturityAndChequeServiceWrapper : IMaturityAndChequeServiceWrapper
    {
        private List<ExportAndReceivedCheque> ExportChequeList = new List<ExportAndReceivedCheque>
        {
            new ExportAndReceivedCheque
            {
                Amount = 2000,
                BankBranch = "انصار",
                Purpose = "پرداخت مبلغ",
                State = true
            }
        };
        public void GetAllExportChequeList(Action<List<ExportAndReceivedCheque>, Exception> action)
        {
            action(ExportChequeList, null);
        }

        private List<ExportAndReceivedCheque> ReceivedChequeList = new List<ExportAndReceivedCheque>
        {
            new ExportAndReceivedCheque
            {
                Amount = 5000,
                BankBranch = "قوامین",
                Purpose = "بروز رسانی اطلاعات",
                State = true
            }
        };
        public void GetAllReceivedChequeList(Action<List<ExportAndReceivedCheque>, Exception> action)
        {
            action(ReceivedChequeList, null);
        }
        private List<OtherFinancialState> demandList = new List<OtherFinancialState>
        {
            new OtherFinancialState
            {
                Amount = 400000,
                Opponent = "علیرضا محمدی",
                State = true,
                Purpose = "تهیه ابزارات شرکت"
            }
        };
        public void GetAllDemandList(Action<List<OtherFinancialState>, Exception> action)
        {
            action(demandList, null);
        }

        private List<OtherFinancialState> debtList = new List<OtherFinancialState>
        {
            new OtherFinancialState
            {
                Amount = 700000,
                Opponent = "اکبر سلطانی",
                State = false,
                Purpose = "تهیه ابزارات ماشین"
            }
        };
        public void GetAllDebtList(Action<List<OtherFinancialState>, Exception> action)
        {
            action(debtList, null);
        }

        private List<OtherFinancialState> otherCommitmentList = new List<OtherFinancialState>
        {
            new OtherFinancialState
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه"
            },
                        new OtherFinancialState
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه"
            },
                        new OtherFinancialState
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه"
            },
                        new OtherFinancialState
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه"
            },
                        new OtherFinancialState
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه"
            },
                        new OtherFinancialState
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه"
            },
                        new OtherFinancialState
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه"
            },            new OtherFinancialState
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه"
            },
                        new OtherFinancialState
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه"
            },
                        new OtherFinancialState
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه"
            },
                        new OtherFinancialState
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه"
            },
                        new OtherFinancialState
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه"
            },
                        new OtherFinancialState
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه"
            },
                        new OtherFinancialState
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه"
            },

        };

        public void GetAllOtherCommitmentsList(Action<List<OtherFinancialState>, Exception> action)
        {
            action(otherCommitmentList, null);
        }
    }
}
