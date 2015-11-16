using System;
using System.Collections.Generic;
using BTE.RMS.Interface.Contract.PersonalStrategicManagement.LifePlaning;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers.PersonalStrategicManagement.LifePlaning
{
    public class LifePlaningServiceWrapper : ILifePlaningServiceWrapper
    {
        private List<HumanTimeInLife> humanTimeList = new List<HumanTimeInLife>
        {
            new HumanTimeInLife
            {
                AllOfLife = 90,
                PassedLife = 0,
                OverLife = 90,
                Time = "سال"
            },
                        new HumanTimeInLife
            {
                AllOfLife = 1080,
                PassedLife = 1,
                OverLife = 1079,
                Time = "ماه"
            },
                        new HumanTimeInLife
            {
                AllOfLife = 4696,
                PassedLife = 2,
                OverLife = 4693,
                Time = "هفته"
            }
        };
        public void GetAllHumanTimes(Action<List<HumanTimeInLife>, Exception> action)
        {
            action(humanTimeList, null);
        }
        private List<My90YearLifePlaning> my90YearLifePlaningList=new List<My90YearLifePlaning>
        {
            new My90YearLifePlaning
            {
                InLife_Year = 50000,
                InLife_Year2 = 0,
                InNightDay_Hour = 2000,
                InNightDay_Hour2 = 0,
                SpendingType = "خواب",
                InOverLife_Year = 0,
                Percent = 33.3,
                Percent2 = 0
            }
        }; 
        public void GetAllMy90YearLifePlanings(Action<List<My90YearLifePlaning>, Exception> action)
        {
            action(my90YearLifePlaningList, null);
        }
    }
}
