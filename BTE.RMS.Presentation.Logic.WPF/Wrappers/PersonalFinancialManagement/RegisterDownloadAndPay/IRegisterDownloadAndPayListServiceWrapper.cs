using System;
using System.Collections.Generic;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public interface IRegisterDownloadAndPayListServiceWrapper:IServiceWrapper
    {
        void GetAllRegisterDownloadList(Action<List<RegisterDownloadAndPay>, Exception> action);
        void GetAllRegisterPayList(Action<List<RegisterDownloadAndPay>, Exception> action);
    }
}
