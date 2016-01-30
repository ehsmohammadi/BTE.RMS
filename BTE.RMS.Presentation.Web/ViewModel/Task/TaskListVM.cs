using System.Collections.Generic;
using BTE.Presentation.Web;
using BTE.RMS.Interface.Contract.Facade;
using BTE.RMS.Interface.Contract.TaskItem;

namespace BTE.RMS.Presentation.Web.ViewModel.Task
{
    public class TaskListVM:IViewModel
    {
        private readonly ITaskFacadeService taskService;

        public TaskListVM(ITaskFacadeService taskService)
        {
            this.taskService = taskService;
        }

        public void Load()
        {
            TaskList = taskService.GetAll();
        }

        public List<SummeryTaskItem> TaskList { get; private set; }


    }
}
