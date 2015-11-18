using System;
using System.Collections.Generic;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers.QuranAndPrayer
{
    public class PrayerTimeServiceWrapper:IPrayerTimeServiceWrapper
    {
        private List<PrayerTimes> prayerTimeList=new List<PrayerTimes>
        {
            new PrayerTimes
            {
                
            }
        }; 
        public void GetAllPrayerTimeList(Action<List<PrayerTimes>, Exception> action)
        {
            action(prayerTimeList, null);
        }
    }
}
