using System;
using System.Collections.Generic;
using System.Linq;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public class FakeReceiptAndPaymentListServiceWrapper : IRegisterReceiptAndPaymentListServiceWrapper
    {
        private List<ReceiptAndPayment> transactionList=new List<ReceiptAndPayment>
        {
            new ReceiptAndPayment
            {
                Amount = 2000,
                CostTopic = new CostTopic
                {
                    Id = 10,
                    MonthlyCost = 60,
                    Title = "پرداخت مبلغ"
                },
                FinancialAccount = new FinancialAccount
                {
                    AccountTitle = "قرض الحسنه",
                    Description = "حساب بانکی",
                    Id=10
                },
                Description = "پرداخت مبلغ",
                Id = 1000,
                TransactionType = TransactionType.Payment
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
