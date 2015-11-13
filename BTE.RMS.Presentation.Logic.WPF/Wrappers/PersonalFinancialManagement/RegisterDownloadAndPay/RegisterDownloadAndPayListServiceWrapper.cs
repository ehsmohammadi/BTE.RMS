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
        private List<SummeryRegisterDownloads> registerDownloadList = new List<SummeryRegisterDownloads>
        {
            new SummeryRegisterDownloads
            {
                AccountTitle = "بانکی",
                Amount = 2000000,
                Description = "حساب بانکی",
                Topic = "خرید خودرو"
            }
        };
        public void GetAllRegisterDownload(Action<List<Interface.Contract.SummeryRegisterDownloads>, Exception> action)
        {
            action(registerDownloadList, null);
        }

        private List<SummeryRegisterPays> registerPayList = new List<SummeryRegisterPays>
        {
            new SummeryRegisterPays
            {
                AccountTitle = "غیر بانکی",
                Amount = 400000,
                Description = "بدهی",
                Topic = "خرید مغازه"
            }
        }; 
        public void GetAllRegisterPay(Action<List<Interface.Contract.SummeryRegisterPays>, Exception> action)
        {
            action(registerPayList, null);
        }
    }
}
