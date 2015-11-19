using System;
using System.Collections.Generic;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers.Settings.PrayerTimeSettings
{
    public interface IPrayerTimeSettingsServiceWrapper:IServiceWrapper
    {
        void CreateCityScaleService(Action<List<CrudCitySettings>, Exception> action);
    }
}
