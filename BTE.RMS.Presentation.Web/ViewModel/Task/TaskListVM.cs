using System.Collections.Generic;
using BTE.RMS.Interface.Contract.TaskItem;

namespace BTE.RMS.Presentation.Web.ViewModel.Task
{
    public class TaskListVM
    {
        public TaskListVM(List<SummeryTaskItem> summeryTasks)
        {
            TaskList = summeryTasks;
        }

        public List<SummeryTaskItem> TaskList { get; set; }


    }
}
