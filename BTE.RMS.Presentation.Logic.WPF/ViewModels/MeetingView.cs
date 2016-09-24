using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Windows.Data;

namespace BTE.RMS.Presentation.Logic.ViewModels
{
    public class MeetingView
    {

        public long Id { get; set; }


        #region Meeting properties

        [Display(Name = "نوع قرار")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int MeetingType { get; set; }


        [Display(Name = "موضوع")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Subject { get; set; }

        [Display(Name = "زمان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string StartDate { get; set; }

        [Display(Name = "ساعت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string StartTime { get; set; }

        public DateTime StartDateTime { get; set; }


        [Display(Name = "مدت جلسه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Duration { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Description { get; set; }

        [Display(Name = "مکان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Address { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        [Display(Name = "حاضرین جلسه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string AttendeesList { get; set; }


        [Display(Name = "دستور جلسه")]
        //[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Agenda { get; set; }

        [Display(Name = "مشروح جلسه")]
        [DataType(DataType.MultilineText)]
        public string Details { get; set; }

        [Display(Name = "مصوبات جلسه")]
        [DataType(DataType.MultilineText)]
        public string Decisions { get; set; }

        //public List<FileViewModel> Files { get; set; }


        #endregion

        #region Reminder

        [Display(Name = "فعالیت تکرار شونده")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int RepeatingType { get; set; }

        [Display(Name = "شیوه یادآوری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int ReminderType { get; set; }

        [Display(Name = "زمان یادآوری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int ReminderTime { get; set; }

        public double Top { get; set; }

        public double Left { get; set; }

        public double Height { get; set; }

        public void Calculate_Size(int index)
        {
            double top = 30;

            string[] arr = this.StartTime.Split(':');
            int hour = Int32.Parse(arr[0]);
            int min = Int32.Parse(arr[1]);
            Console.WriteLine((44d / 60d) + " Minutes");
            top += hour * 44;
            top += min*(44d/60d);;
            Top = top;
            Left += 100*index;
            Height = Duration*44;
        }
        #endregion
    }
}