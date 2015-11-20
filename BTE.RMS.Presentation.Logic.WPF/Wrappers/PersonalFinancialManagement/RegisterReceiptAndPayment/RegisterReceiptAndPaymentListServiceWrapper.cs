using System;
using System.Collections.Generic;
using System.Linq;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Interface.Contract.PersonalFinancialManagement.RegisterReceiptAndPayment;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public class FakeCrudTransactionListServiceWrapper : IRegisterReceiptAndPaymentListServiceWrapper
    {
        private List<CrudTransaction> transactioList = new List<CrudTransaction>
        {
            new CrudTransaction
            {
                AccountTitle = "بانکی",
                Amount = 2000000,
                Description = "حساب بانکی",
                Topic = "خرید خودرو",
                TransactionType = TransactionType.Payment
            },
                        new CrudTransaction
            {
                AccountTitle = "غیر بانکی",
                Amount = 400000,
                Description = "بدهی",
                Topic = "خرید مغازه",
                TransactionType = TransactionType.Receipt
            }
        };
        public void GetAllRegisterReceiptList(Action<List<CrudTransaction>, Exception> action)
        {
            action(transactioList.Where(e => e.TransactionType == TransactionType.Receipt).ToList(), null);
        }

        public void GetAllRegisterPaymentList(Action<List<CrudTransaction>, Exception> action)
        {
            action(transactioList.Where(e=>e.TransactionType==TransactionType.Payment).ToList(),null);
        }
    }
}
