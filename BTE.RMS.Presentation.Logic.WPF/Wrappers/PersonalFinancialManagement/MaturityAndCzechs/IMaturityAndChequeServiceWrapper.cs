using System;
using System.Collections.Generic;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public interface IMaturityAndChequeServiceWrapper:IServiceWrapper
    {
        void GetAllReceivedChequeList(Action<List<SummeryCheque>, Exception> action);
        void GetAllDemandList(Action<List<SummeryFinancialCommitments>, Exception> action);
        void GetAllDebtList(Action<List<SummeryFinancialCommitments>, Exception> action);
        void GetAllOtherCommitmentsList(Action<List<SummeryFinancialCommitments>, Exception> action);
        void GetAllPaymentChequeList(Action<List<SummeryCheque>, Exception> action);
    }
}
