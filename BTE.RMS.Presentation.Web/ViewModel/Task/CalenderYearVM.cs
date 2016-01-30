using System;
using BTE.Presentation.Web;
using BTE.RMS.Presentation.Web.ViewModel.Home;
using MD.PersianDateTime;

namespace BTE.RMS.Presentation.Web.ViewModel.Task
{
    public class CalenderYearVM:IViewModel
    {
        private int year;
        public string YearView { get; set; }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }


        public CalenderYearVM(int year)
        {
            this.year = year;
            YearView = MakeCalender(year);
            if (year == 0)
            {
                this.year = new PersianDateTime(DateTime.Now).Year;
            }
        }

        public static string MakeCalender(int year)
        {
            if (year == 0)
            {
                year = new PersianDateTime(DateTime.Now).Year;
            }
            var persiandate = new PersianDateTime(year, 1, 1);
            string res = "";
            for (int i = 1; i < 5; i++)
            {
                res += "<div class='row'>";
                for (int j = 1; j < 4; j++)
                {

                    res += "<div class='col-md-4' style='text-align: center'>";
                    res += "<div class='cal'>";
                    res += " <table class='cal-table'>";
                    res += "<caption class='cal-caption'>";
                    res += persiandate.GetLongMonthName;
                    //res += monthCounter.ToString();
                    res += "</caption>";
                    res += "<tbody class='cal-body'>";
                    int emptyCells = ((int)persiandate.DayOfWeek + 7 - 6) % 7;
                    int days = persiandate.GetMonthDays;
                    for (int k = 0; k != 42; k++)
                    {
                        if (k % 7 == 0)
                        {
                            res += "<tr>";
                            if (k > 0) res += "</tr>";
                        }

                        if (k < emptyCells || k >= emptyCells + days)
                        {
                            res += "<td class='cal-off'><a href='#'>";
                            res += "-";
                            res += "</a></td>";
                        }
                        else
                        {
                            if (!string.IsNullOrWhiteSpace(TodayVM.GetPersianEvent(persiandate.Month, persiandate.Day)))
                                res += "<td title='" + TodayVM.GetPersianEvent(persiandate.Month, persiandate.Day)
                                       + "'" + " class='cal-check'>";
                            else
                            {
                                if (persiandate.ToDateTime().Date == DateTime.Now.Date)
                                    res += "<td class='cal-today'>";
                                else
                                    res += "<td >";
                            }

                            if (persiandate.DayOfWeek == DayOfWeek.Friday)
                                res += "<a style='color:red;'>";
                            else
                                res += "<a>";


                            var dayNo = "12";
                            res += TodayVM.ToPersianDigit(persiandate.Day.ToString());
                            res += "</a></td>";
                            persiandate = persiandate.AddDays(1);
                        }
                    }
                    res += "</tbody>";
                    res += "</table>";
                    res += "</div>";
                    res += "</div>";
                    persiandate.AddMonths(1);
                }
                res += "</div>";
            }
            return res;
        }
    }
}
