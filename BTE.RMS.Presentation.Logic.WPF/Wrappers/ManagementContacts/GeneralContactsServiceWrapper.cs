using System;
using System.Collections.Generic;
using BTE.RMS.Interface.Contract.ManagementContacts;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers.ManagementContacts
{
    public class GeneralContactsServiceWrapper : IGeneralContactsServiceWrapper
    {
        private List<NecessaryContactCategory> necessaryContactCategoryList = new List<NecessaryContactCategory>
        {
            new NecessaryContactCategory
            {
                ParrentCategory = "تلفن های ضروری"
            },
                        new NecessaryContactCategory
            {
                ParrentCategory = "پیش شماره های کشور های جهان"
            },
                        new NecessaryContactCategory
            {
                ParrentCategory = "پیش شماره های شهر تهران"
            },
                                    new NecessaryContactCategory
            {
                ParrentCategory = "بانک اطلاعات تماس تهران بزرگ",
                ChildCategory = "سینما ها"
            }
        };
        public void GetAllNecessaryContactCategoryList(Action<List<NecessaryContactCategory>, Exception> action)
        {
            action(necessaryContactCategoryList, null);
        }

        private List<SummeryNecessaryPhoneNumber> necessaryPhoneNumberList = new List<SummeryNecessaryPhoneNumber>
        {
            new SummeryNecessaryPhoneNumber
            {
                Title = "آتش نشانی",
                TellNumber =125 
            },
                        new SummeryNecessaryPhoneNumber
            {
                Title = "پلیس",
                TellNumber =110
            },
                        new SummeryNecessaryPhoneNumber
            {
                Title = "اورژانس",
                TellNumber =115
            }
        };

        public void GetAllNecessaryPhoneNumberList(Action<List<SummeryNecessaryPhoneNumber>, Exception> action)
        {
            action(necessaryPhoneNumberList, null);
        }


    }
}
