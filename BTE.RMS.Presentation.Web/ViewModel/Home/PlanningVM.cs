﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MD.PersianDateTime;

namespace BTE.RMS.Presentation.Web.ViewModel.Home
{
    public class PlanningVM
    {
        public string Date { get; set; }
        public string PersianDate { get; set; }

        public string ArabicDate { get; set; }

        public PlanningVM(DateTime date)
        {
            Date = date.ToLongDateString();
            PersianDate=new PersianDateTime(date).ToLongDateString();
            var HijriDTFI = new System.Globalization.CultureInfo("ar-SY", false).DateTimeFormat;
            HijriDTFI.Calendar = new System.Globalization.HijriCalendar();
            HijriDTFI.LongDatePattern = "dd/MM/yyyy";
            //ArabicDate = DateTime.Now.ToString(s);

        }
    }
}