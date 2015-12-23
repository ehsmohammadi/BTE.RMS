using System.ComponentModel.DataAnnotations;

namespace BTE.RMS.Interface.Contract.Web.TaskItem
{
    public class TaskItemDTO:BaseTaskItemDTO
    {
        [Display(Name = "Category")]
        public long CategoryId { get; set; }

        public string Content { get; set; }
    }
}
