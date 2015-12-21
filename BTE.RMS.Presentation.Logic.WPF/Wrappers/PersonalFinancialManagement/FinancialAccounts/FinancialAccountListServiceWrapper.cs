using System;
using System.Collections.Generic;
using System.Linq;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public class FakeFinancialAccountListServiceWrapper:IFinancialAccountListServiceWrapper
    {
        private List<SummeryFinancialAccount> financialAccountList = new List<SummeryFinancialAccount>
        {
            new SummeryFinancialAccount
            {
                AccountTitle = "قرض الحسنه",
                AccountType = AccountType.BankAccount,
                Description = "حساب بانکی",
                ReceiptAndPayment = new ReceiptAndPayment
                {
                    Amount = 200000,
                    TransactionType = TransactionType.Payment,
                }, 
            }
        }; 
        public void GetAllfinancialAccountList(Action<List<SummeryFinancialAccount>, Exception> action)
        {
            action(financialAccountList, null);
        }
    }
}
