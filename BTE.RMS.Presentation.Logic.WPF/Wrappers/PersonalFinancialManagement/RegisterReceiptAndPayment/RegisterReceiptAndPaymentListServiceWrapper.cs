using System;
using System.Collections.Generic;
using System.Linq;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public class FakeReceiptAndPaymentListServiceWrapper : IRegisterReceiptAndPaymentListServiceWrapper
    {
        private List<ReceiptAndPayment> transactionList = new List<ReceiptAndPayment>
        {
            new ReceiptAndPayment
            {
                Amount = 200000,
                CostTopic = new BaseCostTopic
                {
                    Id = 2000,
                    MonthlyCost = 200000000,
                    Title = "هزینه های جاری"
                },
                Description = "هزینه های ماه",
                FinancialAccount = new BaseFinancialAccount
                {
                    AccountTitle = "حساب قرض الحسنه",
                    AccountType = AccountType.BankAccount,
                    Description = "asdasd",
                },
                Id = 1000,
                TransactionType = TransactionType.Payment
            },
                        new ReceiptAndPayment
            {
                Amount = 200000,
                Description = "درآمد های ماه",
                FinancialAccount = new BaseFinancialAccount
                {
                    AccountTitle = "حساب قرض الحسنه",
                    AccountType = AccountType.BankAccount,
                    Description = "asdasd",
                },
                Id = 1000,
                IncomeTopic = new BaseIncomeTopic
                {
                    Id = 1000,
                    MonthlyIncome = 20000000,
                    Title = "درآمد های عاری"
                },
                TransactionType = TransactionType.Receipt
            }
        };
        public void GetAllReceiptList(Action<List<ReceiptAndPayment>, Exception> action)
        {
            action(transactionList.Where(e => e.TransactionType == TransactionType.Receipt).ToList(), null);
        }

        public void GetAllPaymentList(Action<List<ReceiptAndPayment>, Exception> action)
        {
            action(transactionList.Where(e => e.TransactionType == TransactionType.Payment).ToList(), null);
        }
    }
}
