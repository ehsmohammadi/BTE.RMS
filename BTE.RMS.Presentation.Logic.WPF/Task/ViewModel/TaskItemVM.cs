using System.Collections.ObjectModel;
using BTE.Presentation;
using BTE.RMS.Interface.Contract.TaskItem;
using BTE.RMS.Presentation.Logic.WPF.Controller;

namespace BTE.RMS.Presentation.Logic.Task
{
    public class TaskItemVM : WorkspaceViewModel
    {
        #region Fields
        private readonly IRMSController controller;
        private readonly ITaskService taskService;
        #endregion
        #region Properties & BackFields
        private CrudTaskItem selectedTaskItem;

        public CrudTaskItem SelectedTaskItem
        {
            get { return selectedTaskItem; }
            set { this.SetField(p => p.SelectedTaskItem, ref selectedTaskItem, value); }
        }

        private SummeryTaskItem selectedTaskItemList;

        public SummeryTaskItem SelectedTaskItemList
        {
            get { return selectedTaskItemList; }
            set { this.SetField(p => p.SelectedTaskItemList, ref selectedTaskItemList, value); }
        }

        private CrudTaskCategory selectedTaskCategory;

        public CrudTaskCategory SelectedTaskCategory
        {
            get { return selectedTaskCategory; }
            set { this.SetField(p => p.SelectedTaskCategory, ref selectedTaskCategory, value); }
        }

        private TaskItemType selectedTaskItemType;

        public TaskItemType SelectedTaskItemType
        {
            get { return selectedTaskItemType; }
            set { this.SetField(p => p.SelectedTaskItemType, ref selectedTaskItemType, value); }
        }

        private ObservableCollection<CrudTaskCategory> taskCategoryList;

        public ObservableCollection<CrudTaskCategory> TaskCategoryList
        {
            get { return taskCategoryList; }
            set { this.SetField(p => p.TaskCategoryList, ref taskCategoryList, value); }
        }

        private ObservableCollection<TaskItemType> taskItemTypeList;

        public ObservableCollection<TaskItemType> TaskItemTypeList
        {
            get { return taskItemTypeList; }
            set { this.SetField(p => p.TaskItemTypeList, ref taskItemTypeList, value); }
        } 
        private CommandViewModel registerCmd;
        public CommandViewModel RegisterCmd
        {
            get
            {
                if (registerCmd == null)
                {
                    registerCmd = new CommandViewModel("ثبت", new DelegateCommand(register));
                }
                return registerCmd;
            }
        }

        private CommandViewModel backCmd;
        public CommandViewModel BackCmd
        {
            get
            {
                if (backCmd == null)
                {
                    backCmd = new CommandViewModel("بازگشت", new DelegateCommand(back));
                }
                return backCmd;
            }
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
        #region Private Methods

        private void init()
        {
            DisplayName = "یادداشت ها و قرار ملاقات ها";
            SelectedTaskItem=new CrudTaskItem();
            SelectedTaskItemList=new SummeryTaskItem();
            SelectedTaskCategory=new CrudTaskCategory();
            SelectedTaskItemType=new TaskItemType();
            TaskItemTypeList=new ObservableCollection<TaskItemType>();
            TaskCategoryList = new ObservableCollection<CrudTaskCategory>();
        }

        protected override void OnRequestClose()
        {
            base.OnRequestClose();
            controller.Close(this);
        }
        private void register()
        {
            //taskService.RegisterTaskItem(
            //    (res, exp) =>
            //    {
            //        HideBusyIndicator();
            //        if (exp == null)
            //        {
            //            SelectedTaskItem=new CrudTaskItem();
            //        }
            //        else controller.HandleException(exp);
            //    },SelectedTaskItem,SelectedTaskCategory,SelectedTaskItemType);
            //controller.ShowNotesAndAppointmentsListView();
        }
        private void back()
        {
            //controller.ShowNotesAndAppointmentsListView();
        }
        #endregion
        #region Public Methods
        public void Load(SummeryTaskItem item)
        {
            //taskService.GetTaskItem(
            //    (res, exp) =>
            //    {
            //        HideBusyIndicator();
            //        if (exp == null)
            //        {
            //            SelectedTaskItem = res;
            //        }
            //        else controller.HandleException(exp);
            //    },item.Id);
            //taskService.GetAllTaskCategoryList(
            //    (res, exp) =>
            //    {
            //        HideBusyIndicator();
            //        if (exp == null)
            //        {
            //            TaskCategoryList = new ObservableCollection<CrudTaskCategory>(res);
            //        }
            //        else controller.HandleException(exp);
            //    }, SelectedTaskCategory,SelectedTaskItemList);
            //taskService.GetAllTaskItemTypeList(
            //    (res, exp) =>
            //    {
            //        HideBusyIndicator();
            //        if (exp == null)
            //        {
            //            TaskItemTypeList = new ObservableCollection<TaskItemType>(res);
            //        }
            //        else controller.HandleException(exp);
            //    }, SelectedTaskItemType,SelectedTaskItemList);
        }
        public void Load()
        {
            //taskService.GetAllTaskCategoryList(
            //    (res, exp) =>
            //    {
            //        HideBusyIndicator();
            //        if (exp == null)
            //        {
            //            TaskCategoryList = new ObservableCollection<CrudTaskCategory>(res);
            //        }
            //        else controller.HandleException(exp);
            //    }, SelectedTaskCategory,SelectedTaskItemList);
            //taskService.GetAllTaskItemTypeList(
            //    (res, exp) =>
            //    {
            //        HideBusyIndicator();
            //        if (exp == null)
            //        {
            //            TaskItemTypeList = new ObservableCollection<TaskItemType>(res);
            //        }
            //        else controller.HandleException(exp);
            //    }, SelectedTaskItemType,SelectedTaskItemList);
            //taskService.GetAllTaskItem(
            //    (res, exp) =>
            //    {
            //        HideBusyIndicator();
            //        if (exp==null)
            //        {
            //            SelectedTaskItem=new CrudTaskItem();
            //        }
            //        else controller.HandleException(exp);
            //    },SelectedTaskItem);
        }
        #endregion
    }
}
