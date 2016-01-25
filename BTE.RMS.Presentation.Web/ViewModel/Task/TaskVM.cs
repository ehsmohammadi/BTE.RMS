using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BTE.RMS.Interface.Contract.Web.TaskItem;
using MD.PersianDateTime;

namespace BTE.RMS.Presentation.Web.ViewModel.Task
{
    public class TaskVM
    {
        public TaskItemDTO Task { get; set; }

        public string TaskStartDate 
        { 
            get;
            set;
        }

        public List<TaskCategoryDTO> TaskCategories { get; set; }

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

        public TaskVM()
        {
            Update();

        }

        public void Update()
        {
            if (Task != null)
            {
                if (Task.StartDate != null && string.IsNullOrWhiteSpace(TaskStartDate))
                {
                    TaskStartDate = new PersianDateTime(Task.StartDate).ToShortDateString();
                }
                else if (!string.IsNullOrWhiteSpace(TaskStartDate))
                {
                    var date = PersianDateTime.Parse(TaskStartDate);
                    Task.StartDate = date.ToDateTime();
                }
            }
        }


    }
}
