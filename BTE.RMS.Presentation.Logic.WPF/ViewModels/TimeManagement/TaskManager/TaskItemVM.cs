using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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

        private TaskCategory selectedTaskCategory;

        public TaskCategory SelectedTaskCategory
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

        private ObservableCollection<TaskCategory> taskCategoryList;

        public ObservableCollection<TaskCategory> TaskCategoryList
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

        public TaskItemVM(IRMSController controller, ITaskItemServiceWrapper taskItemService)
        {
            this.controller = controller;
            this.taskItemService = taskItemService;
            init();
        }

        #endregion
        #region Private Methods

        private void init()
        {
            DisplayName = "یادداشت ها و قرار ملاقات ها";
            SelectedTaskItem=new CrudTaskItem();
            SelectedTaskItemList=new SummeryTaskItem();
            SelectedTaskCategory=new TaskCategory();
            SelectedTaskItemType=new TaskItemType();
            TaskItemTypeList=new ObservableCollection<TaskItemType>();
            TaskCategoryList=new ObservableCollection<TaskCategory>();
        }

        protected override void OnRequestClose()
        {
            base.OnRequestClose();
            controller.Close(this);
        }
        private void register()
        {
            taskItemService.RegisterTaskItem(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        SelectedTaskItem=new CrudTaskItem();
                    }
                    else controller.HandleException(exp);
                },SelectedTaskItem,SelectedTaskCategory,SelectedTaskItemType);
            controller.ShowNotesAndAppointmentsListView();
        }
        private void back()
        {
            controller.ShowNotesAndAppointmentsListView();
        }
        #endregion
        #region Public Methods
        public void Load(SummeryTaskItem item)
        {
            taskItemService.GetTaskItem(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        SelectedTaskItem = res;
                    }
                    else controller.HandleException(exp);
                },item.Id);
            taskItemService.GetAllTaskCategoryList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        TaskCategoryList = new ObservableCollection<TaskCategory>(res);
                    }
                    else controller.HandleException(exp);
                }, SelectedTaskCategory,SelectedTaskItemList);
            taskItemService.GetAllTaskItemTypeList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        TaskItemTypeList = new ObservableCollection<TaskItemType>(res);
                    }
                    else controller.HandleException(exp);
                }, SelectedTaskItemType,SelectedTaskItemList);
        }
        public void Load()
        {
            taskItemService.GetAllTaskCategoryList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        TaskCategoryList = new ObservableCollection<TaskCategory>(res);
                    }
                    else controller.HandleException(exp);
                }, SelectedTaskCategory,SelectedTaskItemList);
            taskItemService.GetAllTaskItemTypeList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        TaskItemTypeList = new ObservableCollection<TaskItemType>(res);
                    }
                    else controller.HandleException(exp);
                }, SelectedTaskItemType,SelectedTaskItemList);
            taskItemService.GetAllTaskItem(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp==null)
                    {
                        SelectedTaskItem=new CrudTaskItem();
                    }
                    else controller.HandleException(exp);
                },SelectedTaskItem);
        }
        #endregion
    }
}
