using System.Collections.ObjectModel;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Presentation.Logic.WPF.Controller;
using BTE.RMS.Presentation.Logic.WPF.Wrappers;

namespace BTE.RMS.Presentation.Logic.WPF.ViewModels
{
    public class TaskItemListVM : WorkspaceViewModel
    {
        #region Fields
        private readonly IRMSController controller;
        private readonly ITaskItemServiceWrapper taskItemService;

        #endregion

        #region Properties & BackFields
        private ObservableCollection<SummeryTaskItem> taskItemList;

        public ObservableCollection<SummeryTaskItem> TaskItemList
        {
            get { return taskItemList; }
            set
            {
                this.SetField(p => p.TaskItemList, ref taskItemList, value);
            }
        }

        private SummeryTaskItem selectedTaskItem;

        public SummeryTaskItem SelectedTaskItem
        {
            get { return selectedTaskItem; }
            set
            {
                this.SetField(p => p.SelectedTaskItem, ref selectedTaskItem, value);
            }
        }

        private ObservableCollection<TaskCategory> taskCategory;

        public ObservableCollection<TaskCategory> TaskCategory
        {
            get { return taskCategory; }
            set { this.SetField(p => p.TaskCategory, ref taskCategory, value); }
        }

        private TaskCategory selectedCategory;

        public TaskCategory SelectedCategory
        {
            get { return selectedCategory; }
            set { this.SetField(p => p.SelectedCategory, ref selectedCategory, value); }
        }
        private CommandViewModel createCmd;
        public CommandViewModel CreateCmd
        {
            get
            {
                if (createCmd == null)
                {
                    createCmd = new CommandViewModel("یادداشت/قرار ملاقات جدید", new DelegateCommand(create));
                }
                return createCmd;
            }
        }

        private CommandViewModel modifyCmd;
        public CommandViewModel ModifyCmd
        {
            get
            {
                if (modifyCmd == null)
                {
                    modifyCmd = new CommandViewModel("ویرایش", new DelegateCommand(modify));
                }
                return modifyCmd;
            }
        }

        private CommandViewModel deleteCmd;
        public CommandViewModel DeleteCmd
        {
            get
            {
                if (deleteCmd == null)
                {
                    deleteCmd = new CommandViewModel("حذف", new DelegateCommand(delete));
                }
                return deleteCmd;
            }
        }

        #endregion

        #region Constructors

        public TaskItemListVM()
        {
            init();
        }

        public TaskItemListVM(IRMSController controller, ITaskItemServiceWrapper taskItemService)
        {
            this.controller = controller;
            this.taskItemService = taskItemService;
            init();
        }
        #endregion

        #region Private Methods

        private void init()
        {
            DisplayName = "یادداشت ها/قرار ملاقات";
            TaskItemList = new ObservableCollection<SummeryTaskItem>();
            TaskCategory = new ObservableCollection<TaskCategory>();
            SelectedTaskItem=new SummeryTaskItem();
        }

        protected override void OnRequestClose()
        {
            base.OnRequestClose();
            controller.Close(this);
        }

        private void create()
        {
            controller.ShowNotesAndAppointmentsView();
        }

        public void modify()
        {
            controller.ShowNotesAndAppointmentsView();
        }
        public void delete()
        {
            taskItemService.RemoveTaskItem(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        SelectedTaskItem=new SummeryTaskItem();
                    }
                }
                ,SelectedTaskItem);
            controller.ShowNotesAndAppointmentsListView();
        }
        #endregion

        #region Public Methods
        public void Load()
        {
            taskItemService.GetAllTaskItemList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        taskItemList = new ObservableCollection<SummeryTaskItem>(res);
                    }
                    else controller.HandleException(exp);
                });
            taskItemService.GetAllTaskCategory(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        taskCategory = new ObservableCollection<TaskCategory>(res);
                    }
                    else controller.HandleException(exp);
                });
        }
        #endregion
    }
}
