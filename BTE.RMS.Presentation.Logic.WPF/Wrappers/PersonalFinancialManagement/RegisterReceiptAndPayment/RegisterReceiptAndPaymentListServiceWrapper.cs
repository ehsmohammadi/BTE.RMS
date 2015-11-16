using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public class FakeRegisterReceiptAndPaymentListServiceWrapper : IRegisterReceiptAndPaymentListServiceWrapper
    {
        private List<RegisterReceiptAndPayment> registerDownloadList = new List<RegisterReceiptAndPayment>
        {
            new RegisterReceiptAndPayment
            {
                AccountTitle = "بانکی",
                Amount = 2000000,
                Description = "حساب بانکی",
                Topic = "خرید خودرو"
            }
        };
        public void GetAllRegisterDownloadList(Action<List<RegisterReceiptAndPayment>, Exception> action)
        {
            action(registerDownloadList, null);
        }
        private List<RegisterReceiptAndPayment> registerPayList = new List<RegisterReceiptAndPayment>
        {
            new RegisterReceiptAndPayment
            {
                AccountTitle = "غیر بانکی",
                Amount = 400000,
                Description = "بدهی",
                Topic = "خرید مغازه"
            }
        };

        public void GetAllRegisterPayList(Action<List<RegisterReceiptAndPayment>, Exception> action)
        {
            action(registerPayList, null);
        }
    }
}
