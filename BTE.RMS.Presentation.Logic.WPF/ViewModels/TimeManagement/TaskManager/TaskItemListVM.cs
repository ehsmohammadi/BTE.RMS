using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Interface.Contract.TaskItem;
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

        private ObservableCollection<FilterType> filterTypeList;

        public ObservableCollection<FilterType> FilterTypeList
        {
            get { return filterTypeList; }
            set { this.SetField(p => p.FilterTypeList, ref filterTypeList, value); }
        }

        private FilterType selectedFilterType;

        public FilterType SelectedFilterType
        {
            get { return selectedFilterType; }
            set { this.SetField(p => p.SelectedFilterType, ref selectedFilterType, value); }
        }

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
        private ObservableCollection<SummeryTaskItem> taskItemList;

        public ObservableCollection<SummeryTaskItem> TaskItemList
        {
            get { return taskItemList; }
            set { this.SetField(p => p.TaskItemList, ref taskItemList, value); }
        }
        private DateTime selectedDate;

        public DateTime SelectedDate
        {
            get { return selectedDate; }
            set { this.SetField(p => p.SelectedDate, ref selectedDate, value); }
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

        private CommandViewModel filterCmd;

        public CommandViewModel FilterCmd
        {
            get
            {
                if (filterCmd == null)
                {
                    //filterCmd = new CommandViewModel("فیلتر", new DelegateCommand(filtering));
                }
                return filterCmd;
            }
        }
        private CommandViewModel categoryFilterCmd;

        public CommandViewModel CategoryFilterCmd
        {
            get
            {
                if (categoryFilterCmd == null)
                {
                    categoryFilterCmd = new CommandViewModel("فیلتر رسته ها", new DelegateCommand(categoryFilter));
                }
                return categoryFilterCmd;
            }
        }
        //private CommandViewModel taskItemTypeFilterCmd;

        //public CommandViewModel TaskItemTypeFilterCmd
        //{
        //    get
        //    {
        //        if (taskItemTypeFilterCmd == null)
        //        {
        //            taskItemTypeFilterCmd = new CommandViewModel("فیلتر نوع", new DelegateCommand(taskItemTypeFilter));
        //        }
        //        return taskItemTypeFilterCmd;
        //    }
        //}



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
            DisplayName = "یادداشت ها و قرار ملاقات ها";
            SelectedTaskItem = new CrudTaskItem();
            SelectedTaskItemList = new SummeryTaskItem();
            SelectedTaskCategory = new CrudTaskCategory();
            SelectedTaskItemType = new TaskItemType();
            TaskItemTypeList = new ObservableCollection<TaskItemType>();
            TaskCategoryList = new ObservableCollection<CrudTaskCategory>();
            TaskItemList = new ObservableCollection<SummeryTaskItem>();
            FilterTypeList = new ObservableCollection<FilterType>();
            SelectedFilterType = new FilterType();


        }

        private void create()
        {
            controller.ShowNotesAndAppointmentsView();
        }

        private void modify()
        {
            if (SelectedTaskItemList.Id == 0)
            {
                controller.ShowNotesAndAppointmentsListView();
                MessageBox.Show("سطری برای ویرایش وجود ندارد");
            }
            else
            {
                controller.ShowNotesAndAppointmentsView(SelectedTaskItemList);
                taskItemService.UpdateSelectedTaskItem(
                    (res, exp) =>
                    {
                        HideBusyIndicator();
                        if (exp == null)
                        {
                            SelectedTaskItemList = new SummeryTaskItem();
                        }
                        else
                        {
                            controller.HandleException(exp);
                        }
                    }, SelectedTaskItemList);
            }


        }
        private void delete()
        {
            taskItemService.RemoveSelectedTaskItem(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        SelectedTaskItemList = new SummeryTaskItem();
                    }
                    else
                    {
                        controller.HandleException(exp);
                    }
                }
                , SelectedTaskItemList);
            controller.ShowNotesAndAppointmentsListView();
        }

        private void GetAllCateGory()
        {
            taskItemService.GetAllTaskItemList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        TaskItemList = new ObservableCollection<SummeryTaskItem>(res);
                    }
                    else controller.HandleException(exp);
                }, SelectedTaskItemList);
        }
        private void categoryFilter()
        {
            taskItemService.ShowCategoryFilter(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        TaskItemList = new ObservableCollection<SummeryTaskItem>(res);
                    }
                    else
                    {
                        controller.HandleException(exp);
                    }
                }, SelectedTaskCategory);
            //if (SelectedTaskCategory.Id == 1)
            //{
            //    taskItemService.GetAllTaskItemList(
            //        (res, exp) =>
            //        {
            //            HideBusyIndicator();
            //            if (exp == null)
            //            {
            //                TaskItemList = new ObservableCollection<SummeryTaskItem>(res);
            //            }
            //            else controller.HandleException(exp);
            //        }, SelectedTaskItemList);
            //}
            //else
            //{
            //    var sel = TaskItemList.Where(c => c.CategoryName == SelectedTaskCategory.Title);
            //    taskItemService.GetAllTaskItemList(
            //        (res, exp) =>
            //        {
            //            HideBusyIndicator();
            //            if (exp == null)
            //            {
            //                TaskItemList = new ObservableCollection<SummeryTaskItem>(sel);
            //            }
            //            else controller.HandleException(exp);
            //        }, SelectedTaskItemList);
            //}
        }

        private void GetAllItem()
        {
            taskItemService.GetAllTaskItemList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        TaskItemList = new ObservableCollection<SummeryTaskItem>(res);
                    }
                    else controller.HandleException(exp);
                }, SelectedTaskItemList);
        }


        #endregion

        #region Public Methods

        public void Load()
        {
            FilterTypeList = new ObservableCollection<FilterType>
            {
                       new FilterType
                {
                    Title = "تمام یادداشت ها و قرار های ملاقات",
                    Id = 1,
                },
                new FilterType
                {
                    Title = "تمام یادداشت ها",
                    Id = 2

                },
                new FilterType
                {
                    Title = "یادداشت های انجام شده",
                    Id = 3
                },
                new FilterType
                {
                    Title = "یادداشت های انجام نشده",
                    Id = 4
                },
                new FilterType
                {
                    Title = "تمام قرار ملاقات ها",
                    Id = 5
                },
                            new FilterType
                {
                    Title = "قرار ملاقات های انجام شده",
                    Id = 6
                },
                new FilterType
                {
                    Title = "قرار ملاقات های انجام نشده",
                    Id = 7
                }
            };
            GetAllItem();
            SelectedFilterType.Id = FilterTypeList.Min(c => c.Id);
            
            if (TaskItemList.Count > 0)
            {
                var minid = TaskItemList.Min(c => c.Id);
                var sel = TaskItemList.Single(c => c.Id == minid);
                SelectedTaskItemList.Id = sel.Id;
                SelectedTaskItemList.Title = sel.Title;
                SelectedTaskItemList.StartTime = sel.StartTime;
                SelectedTaskItemList.StartDate = sel.StartDate;
                SelectedTaskItemList.EndTime = sel.EndTime;
                SelectedTaskItemList.WorkProgressPercent = sel.WorkProgressPercent;
                //SelectedTaskItemList.CategoryName = sel.CategoryName;
                //SelectedTaskItemList.TaskItemTypeTitle = sel.TaskItemTypeTitle;
            }
            taskItemService.GetAllTaskCategoryList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        TaskCategoryList = new ObservableCollection<CrudTaskCategory>(res);
                    }
                    else controller.HandleException(exp);
                }, SelectedTaskCategory, SelectedTaskItemList);

        }
        #endregion

    }
}
