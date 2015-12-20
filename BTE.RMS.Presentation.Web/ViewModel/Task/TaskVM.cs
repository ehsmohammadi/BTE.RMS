using System.Collections.Generic;
using System.Web.Mvc;
using BTE.RMS.Interface.Contract.Web.TaskItem;

namespace BTE.RMS.Presentation.Web.ViewModel
{
    public class TaskVM
    {
        public TaskItemDTO Task { get; set; }

        public List<TaskCategoryDTO> TaskCategories { get; set; }

        public IEnumerable<SelectListItem> TaskCategoryItems
        {
            get { return new SelectList(TaskCategories, "Id", "Title"); }
        }


    }
}
