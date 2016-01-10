using System;
using System.Collections.Generic;
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

        [Display(Name = "عنوان")]
        public string Title { get; set; }

         [Display(Name = "درصد پیشرفت")]
        public int WorkProgressPercent { get; set; }

        [Display(Name = "تاریخ")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "زمان شروع")]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [Display(Name = "زمان پایان")]
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }




    }
}
