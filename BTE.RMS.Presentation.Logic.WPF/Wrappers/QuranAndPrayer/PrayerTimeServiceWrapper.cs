using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE.RMS.Interface.Contract.QuranAndPrayer;

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
