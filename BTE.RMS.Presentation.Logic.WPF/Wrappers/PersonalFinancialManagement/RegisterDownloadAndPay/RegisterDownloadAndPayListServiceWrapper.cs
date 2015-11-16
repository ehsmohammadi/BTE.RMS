using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public class FakeRegisterDownloadAndPayListServiceWrapper:IRegisterDownloadAndPayListServiceWrapper
    {
        private List<RegisterDownloadAndPay> registerDownloadList = new List<RegisterDownloadAndPay>
        {
            new RegisterDownloadAndPay
            {
                AccountTitle = "بانکی",
                Amount = 2000000,
                Description = "حساب بانکی",
                Topic = "خرید خودرو"
            }
        };
        public void GetAllRegisterDownloadList(Action<List<RegisterDownloadAndPay>, Exception> action)
        {
            action(registerDownloadList, null);
        }
        private List<RegisterDownloadAndPay> registerPayList = new List<RegisterDownloadAndPay>
        {
            new RegisterDownloadAndPay
            {
                AccountTitle = "غیر بانکی",
                Amount = 400000,
                Description = "بدهی",
                Topic = "خرید مغازه"
            }
        };

        public void GetAllRegisterPayList(Action<List<RegisterDownloadAndPay>, Exception> action)
        {
            action(registerPayList, null);
        }
    }
}
