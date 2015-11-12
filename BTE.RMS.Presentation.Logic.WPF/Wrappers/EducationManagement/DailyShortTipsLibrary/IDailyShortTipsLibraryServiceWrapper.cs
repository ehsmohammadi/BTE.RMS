using System;
using System.Collections.Generic;
using BTE.Presentation;
using BTE.RMS.Interface.Contract.EducationManagement;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers.EducationManagement.DailyShortTipsLibrary
{
    public interface IDailyShortTipsLibraryServiceWrapper:IServiceWrapper
    {
        void GetAllDailyShortTipsList(Action<List<DailyShortTips>, Exception> action);
    }
}
