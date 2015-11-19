using System;
using System.Collections.Generic;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers.Settings.PrayerTimeSettings
{
    public class PrayerTimeSettingsServiceWrapper:IPrayerTimeSettingsServiceWrapper
    {
        public void CreateCityScaleService(Action<List<CrudCitySettings>, Exception> action)
        {
            action(new List<CrudCitySettings>(),null );
        }

    }
}
