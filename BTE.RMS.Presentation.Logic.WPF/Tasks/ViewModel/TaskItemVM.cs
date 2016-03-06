using System.Collections.ObjectModel;
using System.Linq;
using BTE.Presentation;
using BTE.RMS.Common;
using BTE.RMS.Interface.Contract.TaskItem;
using BTE.RMS.Presentation.Logic.Controller;
using BTE.RMS.Presentation.Logic.Tasks.Services;

namespace BTE.RMS.Presentation.Logic.Tasks.ViewModel
{
    public class TaskItemVM : WorkspaceViewModel
    {
        #region Fields

        private readonly IRMSController controller;
        private readonly ITaskService taskService;

        #endregion

        #region Properties & BackFields

        private CrudTaskItem taskItem;
        public CrudTaskItem TaskItem
        {
            get { return taskItem; }
            set { this.SetField(p => p.TaskItem, ref taskItem, value); }
        }

        private ObservableCollection<CrudTaskCategory> taskCategoryList;
        public ObservableCollection<CrudTaskCategory> TaskCategoryList
        {
            get { return taskCategoryList; }
            set { this.SetField(p => p.TaskCategoryList, ref taskCategoryList, value); }
        }

        private ObservableCollection<TaskTypeDTO> taskItemTypeList;
        public ObservableCollection<TaskTypeDTO> TaskItemTypeList
        {
            get { return taskItemTypeList; }
            set { this.SetField(p => p.TaskItemTypeList, ref taskItemTypeList, value); }
        }

        public CommandViewModel SaveCmd
        {
            get { return new CommandViewModel("ثبت", new DelegateCommand(save)); }
        }

        public CommandViewModel ReturnToListCmd
        {
            get { return new CommandViewModel("بازگشت", new DelegateCommand((() => controller.ShowTaskListView()))); }
        }

        #endregion

        #region Constructors
        public TaskItemVM()
        {
            init();
        }

        public TaskItemVM(IRMSController controller, ITaskService taskService)
        {
            this.controller = controller;
            this.taskService = taskService;
            init();
        }

        #endregion

        #region Public Methods

        public void Load(long? id)
        {
            if (id.HasValue)
                getTask(id);
            else
                TaskItem.ActionTypeId = (int) EntityActionType.Create;

            getCategories(id);
            getTaskTypes(id);
        }
        
        #endregion

        #region Private Methods

        private void init()
        {
            DisplayName = "یادداشت ها و قرار ملاقات ها";
            TaskItem = new CrudTaskItem();
            TaskItemTypeList = new ObservableCollection<TaskTypeDTO>();
            TaskCategoryList = new ObservableCollection<CrudTaskCategory>();
        }

        private void getTaskTypes(long? id)
        {
            taskService.GetAllTaskType(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        TaskItemTypeList = new ObservableCollection<TaskTypeDTO>(res);
                        if (!id.HasValue && res.Any())
                            TaskItem.TaskTypeId = TaskItemTypeList.First().Id;
                    }
                    else controller.HandleException(exp);
                });
        }

        private void getCategories(long? id)
        {
            taskService.GetAllTaskCategory(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        TaskCategoryList = new ObservableCollection<CrudTaskCategory>(res);
                        if (!id.HasValue && res.Any())
                            TaskItem.CategoryId = TaskCategoryList.First().Id;
                    }
                    else controller.HandleException(exp);
                });
        }

        private void getTask(long? id)
        {
            taskService.GetBy(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        TaskItem = res;
                        TaskItem.ActionTypeId = (int)EntityActionType.Modify;
                    }
                    else
                        controller.HandleException(exp);
                }, id.Value);
        }

        protected override void OnRequestClose()
        {
            base.OnRequestClose();
            controller.Close(this);
        }

        private void save()
        {
            if (TaskItem.Id == 0)
            {
                taskService.CreateTask((res, exp) =>
                {
                    if (exp == null)
                    {
                        OnRequestClose();
                        controller.ShowTaskListView();
                    }

                }, TaskItem);
            }
            else
            {
                taskService.UpdateTask((res, exp) =>
                {
                    if (exp == null)
                    {
                        OnRequestClose();
                        controller.ShowTaskListView();
                    }

                }, TaskItem);
            }
        }

        #endregion
    }
}
