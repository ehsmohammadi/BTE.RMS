using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BTE.Presentation.Web;
using BTE.RMS.Common;
using BTE.RMS.Interface.Contract.Facade;
using BTE.RMS.Interface.Contract.TaskItem;
using BTE.RMS.Presentation.Web.Controllers;
using MD.PersianDateTime;

namespace BTE.RMS.Presentation.Web.ViewModel.Task
{
    public class TaskVM
    {
        #region Properties
        public CrudTaskItem Task { get; set; }

        public string TaskStartDate { get; set; }

        public List<CrudTaskCategory> TaskCategories { get; private set; }

        public IEnumerable<SelectListItem> TaskTypeItems { get; private set; }

        #endregion

        #region Public Methods

        public void Load(long? id, ITaskFacadeService taskService)
        {
            TaskTypeItems = setTaskItemType();
            TaskCategories = taskService.GetAllCategories();
            if (id.HasValue)
            {
                Task = taskService.Get(id.Value);
                TaskStartDate = new PersianDateTime(Task.StartDate).ToShortDateString();
            }

        }
        public void SetTaskStartDate()
        {
            var date = PersianDateTime.Parse(TaskStartDate);
            Task.StartDate = date.ToDateTime();
        }
        #endregion

        #region Private Methods

        private List<SelectListItem> setTaskItemType()
        {
            var selectedItems = new List<SelectListItem>();
            foreach (int value in Enum.GetValues(typeof(TaskType)))
            {
                var text = "یادداشت";
                if (value == 1)
                {
                    text = "قرار ملاقات";
                }
                selectedItems.Add(new SelectListItem { Text = text, Value = value.ToString() });
            }
            //var 
            return selectedItems;
        }
        #endregion

    }
}
