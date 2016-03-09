using System;
using System.Collections.ObjectModel;
using BTE.Presentation;
using BTE.RMS.Interface.Contract.TaskItem;
using BTE.RMS.Presentation.Logic.Controller;
using BTE.RMS.Presentation.Logic.Tasks.Services;

namespace BTE.RMS.Presentation.Logic.Tasks.ViewModel
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
                return new CommandViewModel("یادداشت/قرار ملاقات جدید", new DelegateCommand(() => controller.ShowTaskView(null)));

            }
        }

        public CommandViewModel ModifyCmd
        {
            get
            {
                return new CommandViewModel("ویرایش", new DelegateCommand(() =>
                {
                    if (SelectedTaskItem != null)
                        controller.ShowTaskView(SelectedTaskItem.Id);
                }));
            }
        }

        public CommandViewModel DeleteCmd
        {
            get
            {
                return new CommandViewModel("حذف", new DelegateCommand((delete)));

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
                TaskItemList = new ObservableCollection<SummeryTaskItem>(res);

            });

        }

        #endregion

        #region Private Methods

        private void init()
        {
            DisplayName = "یادداشت ها و قرار ملاقات ها";
            SelectedTaskItem = new SummeryTaskItem();
            TaskItemList = new ObservableCollection<SummeryTaskItem>();

        }

        private void delete()
        {
            if (SelectedTaskItem == null) return;
            var res = controller.ShowConfirmationMessage("تاییدیه حذف ",
                "آیا می خواهید یادداشت / قرار ملاقات مورد نظر را حذف کنید؟");
            if (res)
                taskService.DeleteTask((exp) =>
                {
                    if (exp == null)
                    {
                        controller.ShowMessage("عملیات مورد نظر با موفقیت انجام شد");
                    }
                }, new CrudTaskItem
                {
                    Id = SelectedTaskItem.Id,
                });
        }

        private void handleException(Exception exp)
        {
            throw exp;
        }

        protected override void OnRequestClose()
        {
            base.OnRequestClose();
            controller.Close(this);
        }
        #endregion

    }
}
