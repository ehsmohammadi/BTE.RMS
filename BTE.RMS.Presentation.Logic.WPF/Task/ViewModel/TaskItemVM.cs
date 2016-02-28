using System.Collections.ObjectModel;
using System.Linq;
using BTE.Presentation;
using BTE.RMS.Interface.Contract.TaskItem;
using BTE.RMS.Presentation.Logic.Controller;

namespace BTE.RMS.Presentation.Logic.Task
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
            {
                taskService.GetBy(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                        TaskItem = res;
                    else 
                        controller.HandleException(exp);
                },id.Value);
            }

            taskService.GetAllTaskCategory(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        TaskCategoryList = new ObservableCollection<CrudTaskCategory>(res);
                        if (!id.HasValue)
                            TaskItem.CategoryId = TaskCategoryList.First().Id;
                    }
                    else controller.HandleException(exp);
                });

            taskService.GetAllTaskType(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        TaskItemTypeList = new ObservableCollection<TaskTypeDTO>(res);
                        if (!id.HasValue)
                            TaskItem.TaskTypeId = TaskItemTypeList.First().Id;
                    }
                    else controller.HandleException(exp);
                });
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

        protected override void OnRequestClose()
        {
            base.OnRequestClose();
            controller.Close(this);
        }

        private void save()
        {
            taskService.CreateTask((res, exp) =>
            {
                if (exp == null)
                {
                    OnRequestClose();
                    controller.ShowTaskListView();
                }
                    
            },TaskItem);
        }

        #endregion


    }
}
