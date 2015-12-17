using System;
using System.Collections.Generic;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public interface IRegisterReceiptAndPaymentListServiceWrapper : IServiceWrapper
    {
        void GetAllReceiptList(Action<List<ReceiptAndPayment>, Exception> action);
        void GetAllPaymentList(Action<List<ReceiptAndPayment>, Exception> action);
    }
}
