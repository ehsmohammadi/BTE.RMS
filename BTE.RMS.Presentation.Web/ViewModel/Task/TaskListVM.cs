using System.Collections.Generic;
using BTE.RMS.Interface.Contract.Web.TaskItem;

namespace BTE.RMS.Presentation.Web.ViewModel
{
    public class TaskListVM
    {
        public TaskListVM(List<SummeryTaskItemDTO> summeryTasks)
        {
            TaskList = summeryTasks;
        }

        public List<SummeryTaskItemDTO> TaskList { get; set; }


    }
}
