using System;
using System.Collections.Generic;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public interface IMaturityAndChequeServiceWrapper:IServiceWrapper
    {
        void GetAllReceivedChequeList(Action<List<Cheque>, Exception> action);
        void GetAllDemandList(Action<List<FinancialCommitments>, Exception> action);
        void GetAllDebtList(Action<List<FinancialCommitments>, Exception> action);
        void GetAllOtherCommitmentsList(Action<List<FinancialCommitments>, Exception> action);
        void GetAllPaymentChequeList(Action<List<Cheque>, Exception> action);
    }
}
