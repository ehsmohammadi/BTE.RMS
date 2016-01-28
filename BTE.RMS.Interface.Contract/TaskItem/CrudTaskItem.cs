using System.ComponentModel.DataAnnotations;

namespace BTE.RMS.Interface.Contract.TaskItem
{
    public class CrudTaskItem : BaseTaskItem
    {
        [Display(Name = "رسته")]
        public long CategoryId { get; set; }

        [Display(Name = "متن ")]
        public string Content { get; set; }
    }
}
