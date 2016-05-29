using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTE.RMS.Presentation.Web.ViewModel.Meeting
{
    public class MeetingViewModel
    {
        public long Id { get; set; }


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

        [Display(Name = "مدت جلسه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Duration { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Description { get; set; }

        [Display(Name = "مکان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Address { get; set; }

        [Display(Name = "حاضرین جلسه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public List<AttendeeViewModel> Attendees { get; set; }

        [Display(Name = "فعالیت تکرار شونده")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int RepitingType { get; set; }

        [Display(Name = "شیوه یادآوری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int RemindingType { get; set; }

        [Display(Name = "زمان یادآوری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int TimeReminding { get; set; }

        [Display(Name = "دستور جلسه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Agenda { get; set; }

        [Display(Name = "فایل")]
        public string AttachmentFiles { get; set; }

        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}