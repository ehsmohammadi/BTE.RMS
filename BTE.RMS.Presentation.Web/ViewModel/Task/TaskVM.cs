using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BTE.Presentation.Web;
using BTE.RMS.Interface.Contract.Facade;
using BTE.RMS.Interface.Contract.TaskItem;
using BTE.RMS.Presentation.Web.Controllers;
using MD.PersianDateTime;

namespace BTE.RMS.Presentation.Web.ViewModel.Task
{
    public class TaskVM : IViewModel
    {
        #region Fields
        private readonly ITaskFacadeService taskService;
        #endregion

        #region Properties
        public CrudTaskItem Task { get; set; }

        public string TaskStartDate { get; set; }

        public List<CrudTaskCategory> TaskCategories { get; private set; }

        public IEnumerable<SelectListItem> TaskTypeItems
        {
            get
            {
                var selectedItems = new List<SelectListItem>();
                foreach (int value in Enum.GetValues(typeof(TaskItemType)))
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
        }

        #endregion

        #region Constructors
        public TaskVM(ITaskFacadeService taskService)
        {
            this.taskService = taskService;
        }
        #endregion

        #region Public Methods
        public void Load(long? id)
        {
            TaskCategories = taskService.GetAllCategories();
            if (id.HasValue)
            {
                Task = taskService.Get(id.Value);
                TaskStartDate = new PersianDateTime(Task.StartDate).ToShortDateString();
            }

        }

        public void Create()
        {
            setTaskStartDate();
            taskService.Create(this.Task);
        }

        public void Update()
        {
            // setTaskStartDate();
            taskService.Update(Task);
        }

        public void Delete(long id)
        {
            taskService.Delete(id);
        }
        #endregion

        #region Private Methods
        private void setTaskStartDate()
        {
            var date = PersianDateTime.Parse(TaskStartDate);
            Task.StartDate = date.ToDateTime();
        }
        #endregion


    }
}
