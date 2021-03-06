﻿using System;
using System.Collections.Generic;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public interface IGeneralContactsServiceWrapper:IServiceWrapper
    {
        void GetAllNecessaryPhoneNumberList(Action<List<SummeryNecessaryPhoneNumber>, Exception> action);
        void GetAllNecessaryContactCategoryList(Action<List<NecessaryContactCategory>, Exception> action);
    }
}
