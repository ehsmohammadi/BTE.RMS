using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MD.PersianDateTime;

namespace BTE.RMS.Presentation.Web.ViewModel.Home
{
    public class TodayVM
    {
        public string Date { get; set; }
        public string PersianDate { get; set; }

        public string ArabicDate { get; set; }

        public TodayVM()
        {
            Date = DateTime.Now.ToLongDateString();
            PersianDate = new PersianDateTime(DateTime.Now).ToLongDateString();
            var HijriDTFI = new System.Globalization.CultureInfo("ar-  EG", false).DateTimeFormat;
            HijriDTFI.Calendar = new System.Globalization.HijriCalendar();
            HijriDTFI.ShortDatePattern = "dd/MM/yyyy";
            ArabicDate = DateTime.Now.ToString(HijriDTFI);
        }
    }
}
