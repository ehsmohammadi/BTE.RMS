using System;
using System.Collections.Generic;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public class FakeRegisterReceiptAndPaymentListServiceWrapper : IRegisterReceiptAndPaymentListServiceWrapper
    {
        private List<RegisterReceiptAndPayment> registerReceiptList = new List<RegisterReceiptAndPayment>
        {
            new RegisterReceiptAndPayment
            {
                AccountTitle = "بانکی",
                Amount = 2000000,
                Description = "حساب بانکی",
                Topic = "خرید خودرو"
            }
        };
        public void GetAllRegisterReceiptList(Action<List<RegisterReceiptAndPayment>, Exception> action)
        {
            action(registerReceiptList, null);
        }


        private List<RegisterReceiptAndPayment> registerPaymentList = new List<RegisterReceiptAndPayment>
        {
            new RegisterReceiptAndPayment
            {
                AccountTitle = "غیر بانکی",
                Amount = 400000,
                Description = "بدهی",
                Topic = "خرید مغازه"
            }
        };


        public void GetAllRegisterPaymentList(Action<List<RegisterReceiptAndPayment>, Exception> action)
        {
            action(registerPaymentList, null);
        }
    }
}
