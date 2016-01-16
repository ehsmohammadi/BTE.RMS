using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Presentation.Logic.WPF.Controller;
using BTE.RMS.Presentation.Logic.WPF.Views;
using BTE.RMS.Presentation.Logic.WPF.Wrappers;

namespace BTE.RMS.Presentation.Logic.WPF.ViewModels
{
    public class TaskItemVM : WorkspaceViewModel
    {
       
        #region Fields
        private readonly IRMSController controller;
        private readonly ITaskItemServiceWrapper taskItemService;

        #endregion

        #region Properties & BackFields

        private CrudTaskItem taskItem;

        public CrudTaskItem TaskItem
        {
            get { return taskItem; }
            set { this.SetField(p => p.TaskItem, ref taskItem, value); }
        }

        private ObservableCollection<TaskItemType> taskItemTypeList;

        public ObservableCollection<TaskItemType> TaskItemTypeList
        {
            get { return taskItemTypeList; }
            set { this.SetField(p => p.TaskItemTypeList, ref taskItemTypeList, value); }
        }

        private TaskItemType selectedTaskItemType;

        public TaskItemType SelectedTaskItemType
        {
            get { return selectedTaskItemType; }
            set { this.SetField(p => p.SelectedTaskItemType, ref selectedTaskItemType, value); }
        }
        private ObservableCollection<TaskCategory> taskCategoryList;

        public ObservableCollection<TaskCategory> TaskCategoryList
        {
            get { return taskCategoryList; }
            set { this.SetField(p => p.TaskCategoryList, ref taskCategoryList, value); }
        }

        private TaskCategory selectedTaskCategory;

        public TaskCategory SelectedTaskCategory
        {
            get { return selectedTaskCategory; }
            set { this.SetField(p => p.SelectedTaskCategory, ref selectedTaskCategory, value); }
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

        public TaskItemVM(IRMSController controller, ITaskItemServiceWrapper taskItemService)
        {
            this.controller = controller;
            this.taskItemService = taskItemService;
            init();
        }

        public TaskItemVM()
        {
            init();
        }

        #endregion

        #region Private Methods
        private void init()
        {
            DisplayName = "ثبت یادداشت ها/قرار ملاقات جدید";
            TaskCategoryList = new ObservableCollection<TaskCategory>();
            TaskItemTypeList = new ObservableCollection<TaskItemType>();
            TaskItem=new CrudTaskItem();
        }
        protected override void OnRequestClose()
        {
            base.OnRequestClose();
            controller.Close(this);
        }
        private void register()
        {
            
            taskItemService.CreateTaskItem((res, exp) =>
            {
                HideBusyIndicator();
                if (exp == null)
                {
                    taskItem=new CrudTaskItem();
                }
                else
                {
                    controller.HandleException(exp);
                }
            },taskItem,SelectedTaskCategory,SelectedTaskItemType);
            controller.ShowNotesAndAppointmentsListView();
        }
        private void back()
        {
            controller.ShowNotesAndAppointmentsListView();
        }
        #endregion

        #region Public Methods
        public void Load()
        {
            taskItemService.GetAllTaskCategory(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        TaskCategoryList = new ObservableCollection<TaskCategory>(res);
                    }
                    else controller.HandleException(exp);
                });
            taskItemService.GetAllTaskItemType(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        TaskItemTypeList = new ObservableCollection<TaskItemType>(res);
                    }
                    else controller.HandleException(exp);
                });
        }
        #endregion
    }
}
