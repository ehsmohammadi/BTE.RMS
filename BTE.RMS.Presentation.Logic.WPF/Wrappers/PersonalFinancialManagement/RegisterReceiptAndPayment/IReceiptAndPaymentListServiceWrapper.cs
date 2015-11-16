using System;
using System.Collections.Generic;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public interface IRegisterReceiptAndPaymentListServiceWrapper : IServiceWrapper
    {
        void GetAllRegisterDownloadList(Action<List<RegisterReceiptAndPayment>, Exception> action);
        void GetAllRegisterPayList(Action<List<RegisterReceiptAndPayment>, Exception> action);
    }
}
