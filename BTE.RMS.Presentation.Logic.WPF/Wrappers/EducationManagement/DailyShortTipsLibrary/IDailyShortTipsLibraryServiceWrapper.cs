using System;
using System.Collections.Generic;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public interface IDailyShortTipsLibraryServiceWrapper:IServiceWrapper
    {
        void GetAllDailyShortTipList(Action<List<DailyShortTip>, Exception> action);
    }
}
