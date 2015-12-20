using System;
using System.Collections.Generic;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public class FakeFinancialAccountListServiceWrapper:IFinancialAccountListServiceWrapper
    {
        private List<SummeryFinancialAccount> financialAccountList = new List<SummeryFinancialAccount>
        {
            new SummeryFinancialAccount
            {
                Id = 1,
                AccountTitle = "قرض الحسنه",
                Description = "حساب بانکی",

            },
            new SummeryFinancialAccount
            {
                Id = 2,
                AccountTitle = "پرداخت های علنی",
                Description = "طلب های شرکتی",
            }
        }; 
        public void GetAllfinancialAccountList(Action<List<SummeryFinancialAccount>, Exception> action)
        {
            action(financialAccountList, null);
        }
    }
}
