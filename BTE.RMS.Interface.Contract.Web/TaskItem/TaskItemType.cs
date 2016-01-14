using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
