using System;
using System.Collections.Generic;
using BTE.Presentation;
using BTE.RMS.Interface.Contract.ManagementContacts;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers.ManagementContacts
{
    public interface IGeneralContactsServiceWrapper:IServiceWrapper
    {
        void GetAllGeneralContactList(Action<List<GeneralContact>, Exception> action);
    }
}
