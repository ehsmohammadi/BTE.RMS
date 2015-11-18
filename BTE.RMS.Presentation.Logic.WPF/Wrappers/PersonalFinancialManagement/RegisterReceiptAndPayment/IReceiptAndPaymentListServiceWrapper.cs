using System;
using System.Collections.Generic;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public interface IRegisterReceiptAndPaymentListServiceWrapper : IServiceWrapper
    {
        void GetAllRegisterReceiptList(Action<List<RegisterReceiptAndPayment>, Exception> action);
        void GetAllRegisterPaymentList(Action<List<RegisterReceiptAndPayment>, Exception> action);
    }
}
