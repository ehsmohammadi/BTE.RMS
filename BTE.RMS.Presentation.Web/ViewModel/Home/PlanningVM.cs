﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
            ArabicDate = date.ToString("dddd،d MMMM yyyy", new CultureInfo("ar-SA"));
        }
    }
}
