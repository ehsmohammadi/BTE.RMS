using System.ComponentModel.DataAnnotations;

namespace BTE.RMS.Interface.Contract.Web.TaskItem
{
    public class TaskItemDTO:BaseTaskItemDTO
    {
        [Display(Name = "رسته")]
        public long CategoryId { get; set; }

        [Display(Name = "متن ")]
        public string Content { get; set; }
    }
}
