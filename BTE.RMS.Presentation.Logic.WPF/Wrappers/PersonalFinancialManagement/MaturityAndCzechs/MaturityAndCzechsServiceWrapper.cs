using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Policy;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Interface.Contract.PersonalFinancialManagement.MaturityAndCzech;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers.PersonalFinancialManagement.MaturityAndCzechs
{
    public class FakeMaturityAndCzechsServiceWrapper : IMaturityAndCzechsServiceWrapper
    {
        private List<SummeryIssuedCzech> issuedCzeshList = new List<SummeryIssuedCzech>
        {
            new SummeryIssuedCzech
            {
                Amount = 2000,
                BankBranch = "انصار",
                Purpose = "پرداخت مبلغ",
                State = true
            }
        };

        public void GetAllIssuedCzechList(System.Action<List<SummeryIssuedCzech>, System.Exception> action)
        {
            action(issuedCzeshList, null);
        }

        private List<SummeryCzechsReceived> czechsReceivedList = new List<SummeryCzechsReceived>
        {
            new SummeryCzechsReceived
            {
                Amount = 5000,
                BankBranch = "قوامین",
                Purpose = "بروز رسانی اطلاعات",
                State = true
            }
        };
        public void GetAllCzechsReceivedList(System.Action<List<Interface.Contract.PersonalFinancialManagement.MaturityAndCzech.SummeryCzechsReceived>, System.Exception> action)
        {
            action(czechsReceivedList, null);
        }

        private List<SummeryDemands> demandList = new List<SummeryDemands>
        {
            new SummeryDemands
            {
                Amount = 400000,
                Opponent = "علیرضا محمدی",
                State = true,
                Purpose = "تهیه ابزارات شرکت"
            }
        };
        public void GetAllDemandList(System.Action<List<SummeryDemands>, System.Exception> action)
        {
            action(demandList, null);
        }

        private List<SummeryDebts> debtList = new List<SummeryDebts>
        {
            new SummeryDebts
            {
                Amount = 700000,
                Opponent = "اکبر سلطانی",
                State = false,
                Purpose = "تهیه ابزارات ماشین"
            }
        };
        public void GetAllDebtList(System.Action<List<SummeryDebts>, System.Exception> action)
        {
            action(debtList, null);
        }

        private List<SummeryOtherCommitments> otherCommitmentsesList = new List<SummeryOtherCommitments>
        {
            new SummeryOtherCommitments
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه"
            },
                        new SummeryOtherCommitments
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه"
            },
                        new SummeryOtherCommitments
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه"
            },
                        new SummeryOtherCommitments
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه"
            },
                        new SummeryOtherCommitments
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه"
            },
                        new SummeryOtherCommitments
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه"
            },
                        new SummeryOtherCommitments
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه"
            },            new SummeryOtherCommitments
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه"
            },
                        new SummeryOtherCommitments
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه"
            },
                        new SummeryOtherCommitments
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه"
            },
                        new SummeryOtherCommitments
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه"
            },
                        new SummeryOtherCommitments
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه"
            },
                        new SummeryOtherCommitments
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه"
            },
                        new SummeryOtherCommitments
            {
                Amount = 300000,
                Opponent = "محمد خبیری",
                State = true,
                Purpose = "تهیه ابزارات شبکه"
            },

        };

        public void GetAllOtherCommitmentsList(System.Action<List<SummeryOtherCommitments>, System.Exception> action)
        {
            action(otherCommitmentsesList, null);
        }
    }
}
