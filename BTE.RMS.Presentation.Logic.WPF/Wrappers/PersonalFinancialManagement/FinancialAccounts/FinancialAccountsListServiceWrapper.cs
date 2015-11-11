using System;
using System.Collections.Generic;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public class FakeFinancialAccountsListServiceWrapper:IFinancialAccountsListServiceWrapper
    {
        private List<SummeryFinancialAccounts> financialAccountList = new List<SummeryFinancialAccounts>
        {
            new SummeryFinancialAccounts
            {
                Id = 1,
                AccountTitle = "بانکی",
                Cash = 2000000
            }
        }; 
        public void GetAllfinancialAccountList(Action<List<SummeryFinancialAccounts>, Exception> action)
        {
            action(financialAccountList, null);
        }
    }
}
