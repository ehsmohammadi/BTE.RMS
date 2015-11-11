using System;
using System.Collections.Generic;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Interface.Contract.PersonalFinancialManagement.MaturityAndCzech;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers.PersonalFinancialManagement.MaturityAndCzechs
{
    public interface IMaturityAndCzechsServiceWrapper:IServiceWrapper
    {
        void GetAllIssuedCzechList(Action<List<SummeryIssuedCzech>, Exception> action);
        void GetAllCzechsReceivedList(Action<List<SummeryCzechsReceived>, Exception> action);
        void GetAllDemandList(Action<List<SummeryDemands>, Exception> action);
        void GetAllDebtList(Action<List<SummeryDebts>, Exception> action);
        void GetAllOtherCommitmentsList(Action<List<SummeryOtherCommitments>, Exception> action);
    }
}
