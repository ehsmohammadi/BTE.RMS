using System;
using System.Collections.Generic;
using BTE.Presentation;
using BTE.RMS.Interface.Contract.ManagementContacts;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers.ManagementContacts
{
    public interface IGeneralContactsServiceWrapper:IServiceWrapper
    {
        void GetAllNecessaryPhoneNumberList(Action<List<SummeryNecessaryPhoneNumber>, Exception> action);
        void GetAllNecessaryContactCategoryList(Action<List<NecessaryContactCategory>, Exception> action);
    }
}
