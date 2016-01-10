using System;
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

        public IEnumerable<SelectListItem> TaskTypeItems
        {
            get
            {
                var selectedItems = new List<SelectListItem>();
                foreach (int value in Enum.GetValues(typeof(TaskItemType)))
                {
                    var text = "یادداشت";
                    if (value==1)
                    {
                        text = "قرار ملاقات";
                    }
                    selectedItems.Add(new SelectListItem { Text = text, Value = value.ToString() });
                }
                //var 
                return selectedItems;
            }
        }


    }
}
