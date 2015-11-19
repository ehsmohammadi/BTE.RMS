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
                ReSource = "جملات قصار",
                Text = "كم تحركي جسمي، گاه منجر به كاهش فعاليت هاي ذهني مي شود. بسياري از آقايان نياز به كار در بيرون خانه دارند تا بتوانند تصوير مثبتي از خود داشته باشند، يا به اين وسيله اختلالات قلبي ارثي را از خود دور كنند. اما هر كسي- چه زن و چه مرد- بدون استثنا زماني كه از نظر جسمي، متناسب و موزون باشد، احساس بهتري دارد. ورزش به شما روحيه اي شاداب مي دهد و در درازمدت، احساس خواهيد كرد كه براي انجام هر كاري توانا هستيد."
            }
        }; 
        public void GetAllDailyShortTipsList(Action<List<DailyShortTip>, Exception> action)
        {
            action(dailyShortTipList, null);
        }
    }
}
