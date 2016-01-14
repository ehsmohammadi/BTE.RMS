using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTE.RMS.Interface.Contract.Web.TaskItem
{
    public class BaseTaskItemDTO
    {
        public long Id { get; set; }

        [Display(Name = "یادداشت /قرار ملاقات")]
        public TaskItemType TaskItemType { get; set; }
        [Required(ErrorMessage = "عنوان الزامی است")]
        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Required(ErrorMessage = "درصد پیشرفت الزامی است")]
        [Range(0,100,ErrorMessage = "درصد پیشرفت می بایست در بازه 0 تا 100 باشد")]
        [Display(Name = "درصد پیشرفت")]
        public int WorkProgressPercent { get; set; }

        [Required(ErrorMessage = "تاریخ الزامی است")]
        [Display(Name = "تاریخ")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "زمان شروع الزامی است")]
        [Display(Name = "زمان شروع")]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "زمان پایان الزامی است")]
        [Display(Name = "زمان پایان")]
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }




    }
}
