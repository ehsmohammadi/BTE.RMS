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
                ParrentCategory = "تلفن های ضروری"
            },
                        new GeneralContact
            {
                ParrentCategory = "پیش شماره های کشور های جهان"
            },
                        new GeneralContact
            {
                ParrentCategory = "پیش شماره های شهر تهران"
            },
                                    new GeneralContact
            {
                ParrentCategory = "بانک اطلاعات تماس تهران بزرگ",
                ChildCategory = "سینما ها"
            }
        }; 
        public void GetAllGeneralContactList(Action<List<GeneralContact>, Exception> action)
        {
            action(generalContactList, null);
        }
    }
}
