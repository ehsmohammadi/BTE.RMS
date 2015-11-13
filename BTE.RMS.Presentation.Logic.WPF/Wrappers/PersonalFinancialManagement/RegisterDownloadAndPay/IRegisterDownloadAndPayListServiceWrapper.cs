using System;
using System.Collections.Generic;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public interface IRegisterDownloadAndPayListServiceWrapper:IServiceWrapper
    {
        void GetAllRegisterDownload(Action<List<SummeryRegisterDownloads>, Exception> action);
        void GetAllRegisterPay(Action<List<SummeryRegisterPays>, Exception> action);
    }
}
