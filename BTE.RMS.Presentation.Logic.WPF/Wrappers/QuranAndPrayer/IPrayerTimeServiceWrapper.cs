using System;
using System.Collections.Generic;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers.QuranAndPrayer
{
    public interface IPrayerTimeServiceWrapper:IServiceWrapper
    {
        void GetAllPrayerTimeList(Action<List<PrayerTimes>, Exception> action);
    }
}
