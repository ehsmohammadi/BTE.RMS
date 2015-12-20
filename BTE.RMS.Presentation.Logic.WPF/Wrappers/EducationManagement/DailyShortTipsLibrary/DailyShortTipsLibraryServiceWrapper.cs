using System;
using System.Collections.Generic;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public class DailyShortTipsLibraryServiceWrapper:IDailyShortTipsLibraryServiceWrapper
    {
        private List<DailyShortTip> dailyShortTipList=new List<DailyShortTip>
        {
            new DailyShortTip
            {
                Id = 1000,
                Context = "سلام بر ایران",
                Description = "یعنی سلام بر ایران",
                Name = "مطالب آموزشی روز",
                Source = "کتابخانه ملی",
            }
        }; 

        public void GetAllDailyShortTipList(Action<List<DailyShortTip>, Exception> action)
        {
            action(dailyShortTipList, null);
        }
    }
}
