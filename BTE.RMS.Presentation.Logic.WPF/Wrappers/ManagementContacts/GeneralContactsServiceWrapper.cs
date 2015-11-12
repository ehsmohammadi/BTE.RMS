using System;
using System.Collections.Generic;
using BTE.RMS.Interface.Contract.ManagementContacts;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers.ManagementContacts
{
    public class GeneralContactsServiceWrapper:IGeneralContactsServiceWrapper
    {
        private List<GeneralContact> generalContactList=new List<GeneralContact>
        {
            new GeneralContact
            {
                Name = "آتش نشانی"
            },
            new GeneralContact()
            {
                Name = "اورژانس"
            }
        }; 
        public void GetAllGeneralContactList(Action<List<GeneralContact>, Exception> action)
        {
            action(generalContactList, null);
        }
    }
}
