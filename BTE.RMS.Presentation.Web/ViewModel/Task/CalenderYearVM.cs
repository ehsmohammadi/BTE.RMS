using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Mvc;
using BTE.RMS.Interface.Contract.Web.TaskItem;
using BTE.RMS.Presentation.Web.ViewModel.Home;
using MD.PersianDateTime;

namespace BTE.RMS.Presentation.Web.ViewModel
{
    public class CalenderYearVM
    {
        public string YearView { get; set; }
        public CalenderYearVM()
        {
            makeCalender();
        }

        private void makeCalender()
        {
            var year = 1394;
            var monthCounter = 1;
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
                    var persiandate = new PersianDateTime(year, monthCounter, 1);
                    res += persiandate.GetLongMonthName;
                    //res += monthCounter.ToString();
                    res += "</caption>";
                    res += "<tbody class='cal-body'>";
                    int emptyCells = ((int)persiandate.DayOfWeek + 7 - 1) % 7;
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
                            //if (k < emptyCells)
                            //    res += TodayVM.ToPersianDigit(k.ToString());
                            //if (k >= emptyCells + days)
                            //    res += TodayVM.ToPersianDigit((k-days).ToString());
                            res += "</a></td>";
                        }
                        else
                        {
                            res += "<td><a href='#'>";
                            var dayNo = "12";
                            res += TodayVM.ToPersianDigit(persiandate.Day.ToString());
                            res += "</a></td>";
                            persiandate = persiandate.AddDays(1);
                        }
                    }
                    //for (int k = 0; k < 6; k++)
                    //{
                    //    res += "<tr>";
                    //    for (int l = 0; l < 7; l++)
                    //    {
                    //        res += "<td><a href='#'>";
                    //        var dayNo = "12";
                    //        res += TodayVM.ToPersianDigit(dayNo);                           
                    //        res += "</a></td>";
                    //    }
                    //    res += "</tr>";
                    //}
                    res += "</tbody>";
                    res += "</table>";
                    res += "</div>";
                    res += "</div>";
                    monthCounter++;
                }
                res += "</div>";
            }
            YearView = res;
        }
    }
}
