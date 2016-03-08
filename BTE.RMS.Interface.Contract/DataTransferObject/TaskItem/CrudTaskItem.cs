using System;
using System.ComponentModel.DataAnnotations;

namespace BTE.RMS.Interface.Contract.TaskItem
{
    public class CrudTaskItem// : BaseTaskItem
    {

        public Guid SyncId { get; set; }

        public int ActionTypeId { get; set; }

        #region Main properties
        public long Id { get; set; }

        [Display(Name = "یادداشت /قرار ملاقات")]
        public int TaskTypeId { get; set; }

        //[Required(ErrorMessage = "عنوان الزامی است")]
        [Display(Name = "عنوان")]
        public string Title { get; set; }

        //[Required(ErrorMessage = "درصد پیشرفت الزامی است")]
        //[Range(0,100,ErrorMessage = "درصد پیشرفت می بایست در بازه 0 تا 100 باشد")]
        [Display(Name = "درصد پیشرفت")]
        public int WorkProgressPercent { get; set; }

        [Display(Name = "تاریخ")]
        public DateTime? StartDate { get; set; }

        //[Required(ErrorMessage = "زمان شروع الزامی است")]
        [Display(Name = "زمان شروع")]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        //[Required(ErrorMessage = "زمان پایان الزامی است")]
        [Display(Name = "زمان پایان")]
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }
        [Display(Name = "رسته")]
        public long CategoryId { get; set; }

        [Display(Name = "متن ")]
        public string Content { get; set; } 
        #endregion
    }
}
