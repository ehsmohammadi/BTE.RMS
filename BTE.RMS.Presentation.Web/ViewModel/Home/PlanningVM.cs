using System;
using System.Globalization;
using BTE.Presentation.Web;
using MD.PersianDateTime;

namespace BTE.RMS.Presentation.Web.ViewModel.Home
{
    public class PlanningVM : IViewModel
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
