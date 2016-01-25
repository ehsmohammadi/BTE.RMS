using System.ComponentModel.DataAnnotations;

namespace BTE.RMS.Interface.Contract.Web.TaskItem
{
    public enum TaskItemType
    {
        [Display(Name = "یادداشت")]
        Note=0,
        [Display(Name = "قرار ملاقات")]
        Appointment=1
    }
}
