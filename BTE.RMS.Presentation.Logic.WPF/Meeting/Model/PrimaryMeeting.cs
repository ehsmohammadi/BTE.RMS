using System.ComponentModel.DataAnnotations;
using BTE.Presentation;
using BTE.RMS.Presentation.Logic.WPF.PersianDate;

namespace BTE.RMS.Presentation.Logic.Meeting.Model
{
    [MetadataType(typeof(PrimaryMeeting))]
    public class PrimaryMeeting: WorkspaceViewModel 
    {
        public long Id { get; set; }
        public string Type { get; set; }

        [StringLength(50),Required(ErrorMessage = "عنوان الزامی است")]
        [Display(Name = "عنوان")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "زمان الزامی است ")]
        [Display(Name = "زمان")]
        public PersianDate Date { get; set; }

        public string Duration { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }
        public string Attendees { get; set; }

    }
}
