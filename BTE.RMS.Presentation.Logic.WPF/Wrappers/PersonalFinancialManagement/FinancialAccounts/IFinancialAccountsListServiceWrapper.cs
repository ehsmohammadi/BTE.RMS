using System;
using System.Collections.Generic;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public interface IFinancialAccountsListServiceWrapper:IServiceWrapper
    {
        void GetAllfinancialAccountList(Action<List<SummeryFinancialAccounts>, Exception> action);
    }
}
