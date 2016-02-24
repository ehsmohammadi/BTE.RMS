using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Windows;
using BTE.Presentation;
using BTE.RMS.Interface.Contract.TaskItem;
using BTE.RMS.Presentation.Logic.WPF.Controller;

namespace BTE.RMS.Presentation.Logic.Task
{
    public class TaskItemListVM : WorkspaceViewModel
    {
        #region Fields
        private readonly IRMSController controller;
        private readonly ITaskService taskService;
        #endregion

        #region Properties & BackFields

        private SummeryTaskItem selectedTaskItem;
        public SummeryTaskItem SelectedTaskItem
        {
            get { return selectedTaskItem; }
            set { this.SetField(p => p.SelectedTaskItem, ref selectedTaskItem, value); }
        }

        private ObservableCollection<SummeryTaskItem> taskItemList;
        public ObservableCollection<SummeryTaskItem> TaskItemList
        {
            get { return taskItemList; }
            set { this.SetField(p => p.TaskItemList, ref taskItemList, value); }
        }

        public CommandViewModel CreateCmd
        {
            get
            {
                return new CommandViewModel("یادداشت/قرار ملاقات جدید", new DelegateCommand(create));

            }
        }

        public CommandViewModel ModifyCmd
        {
            get
            {
                return new CommandViewModel("ویرایش", new DelegateCommand(modify));
            }
        }

        public CommandViewModel DeleteCmd
        {
            get
            {
                return new CommandViewModel("حذف", new DelegateCommand(delete));

            }
        }

        #endregion

        #region Constructors

        public TaskItemListVM()
        {
            init();
        }

        public TaskItemListVM(IRMSController controller, ITaskService taskService)
        {
            this.controller = controller;
            this.taskService = taskService;
            init();
        }

        #endregion

        #region Public Methods

        public void Load()
        {
            taskService.GetAll((res, exp) =>
            {
                if (exp != null)
                    handleException(exp);
                TaskItemList=new ObservableCollection<SummeryTaskItem>(res);

            });

        }

        private void handleException(Exception exp)
        {
            throw exp;
        }

        #endregion

        #region Private Methods
        private void init()
        {
            DisplayName = "یادداشت ها و قرار ملاقات ها";
            SelectedTaskItem = new SummeryTaskItem();
            TaskItemList = new ObservableCollection<SummeryTaskItem>();


        }

        private void create()
        {

        }

        private void modify()
        {
           
           

        }
        private void delete()
        {
            
        }

        #endregion

    }
}
