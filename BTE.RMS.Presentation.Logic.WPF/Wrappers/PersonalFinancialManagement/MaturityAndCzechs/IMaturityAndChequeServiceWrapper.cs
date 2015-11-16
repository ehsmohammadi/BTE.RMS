using System;
using System.Collections.Generic;
using BTE.Presentation;
using BTE.RMS.Interface.Contract.PersonalFinancialManagement.MaturityAndCzech;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers.PersonalFinancialManagement.MaturityAndCzechs
{
    public interface IMaturityAndChequeServiceWrapper:IServiceWrapper
    {
        void GetAllExportChequeList(Action<List<Cheque>, Exception> action);
        void GetAllReceivedChequeList(Action<List<Cheque>, Exception> action);
        void GetAllDemandList(Action<List<FinancialCommitments>, Exception> action);
        void GetAllDebtList(Action<List<FinancialCommitments>, Exception> action);
        void GetAllOtherCommitmentsList(Action<List<FinancialCommitments>, Exception> action);
    }
}
