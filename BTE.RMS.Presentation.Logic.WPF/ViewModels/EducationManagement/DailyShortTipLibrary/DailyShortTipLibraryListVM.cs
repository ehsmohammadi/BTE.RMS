using System;
using System.Collections.ObjectModel;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Presentation.Logic.WPF.Controller;
using BTE.RMS.Presentation.Logic.WPF.Wrappers;

namespace BTE.RMS.Presentation.Logic.WPF.ViewModels
{
    public class DailyShortTipLibraryListVM : WorkspaceViewModel
    {


        #region Fields
        private readonly IRMSController controller;
        private readonly ILibraryServiceWrapper libraryService;

        #endregion

        #region Properties & BackFields
        private ObservableCollection<CrudLibrary> libraryNameList;

        public ObservableCollection<CrudLibrary> LibraryNameList
        {
            get { return libraryNameList; }
            set { this.SetField(p => p.LibraryNameList, ref libraryNameList, value); }
        }

        private CrudLibrary selectedLibraryName;

        public CrudLibrary SelectedLibraryName
        {
            get { return selectedLibraryName; }
            set { this.SetField(p => p.SelectedLibraryName, ref selectedLibraryName, value); }
        }

        private ObservableCollection<SummeryDailyShortTip> dailyShortTipList;

        public ObservableCollection<SummeryDailyShortTip> DailyShortTipList
        {
            get { return dailyShortTipList; }
            set { this.SetField(p => p.DailyShortTipList, ref dailyShortTipList, value); }
        }

        private SummeryDailyShortTip selectedDailyShortTip;

        public SummeryDailyShortTip SelectedDailyShortTip
        {
            get { return selectedDailyShortTip; }
            set { this.SetField(p => p.SelectedDailyShortTip, ref selectedDailyShortTip, value); }
        }

        private CommandViewModel showLibraryCmd;

        public CommandViewModel ShowLibraryCmd
        {
            get
            {
                if (showLibraryCmd == null)
                {
                    showLibraryCmd = new CommandViewModel("[نمایش]", new DelegateCommand(showLibrary));
                }
                return showLibraryCmd;
            }
        }
        private CommandViewModel showDateFilterCmd;

        public CommandViewModel ShowDateFilterCmd
        {
            get
            {
                if (showDateFilterCmd == null)
                {
                    showDateFilterCmd = new CommandViewModel("[نمایش]", new DelegateCommand(showDateFilter));
                }
                return showDateFilterCmd;
            }
        }
        private CommandViewModel createCmd;
        public CommandViewModel CreateCmd
        {
            get
            {
                if (createCmd == null)
                {
                    createCmd = new CommandViewModel("کتابخانه جدید", new DelegateCommand(create));
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
                    modifyCmd = new CommandViewModel("ویرایش کتابخانه", new DelegateCommand(modify));
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
                    deleteCmd = new CommandViewModel("حذف کتابخانه", new DelegateCommand(delete));
                }
                return deleteCmd;
            }
        }

        #endregion

        #region Constructors

        public DailyShortTipLibraryListVM()
        {
            init();
        }
        public DailyShortTipLibraryListVM(IRMSController controller, ILibraryServiceWrapper libraryService)
        {
            init();
            this.controller = controller;
            this.libraryService = libraryService;
        }


        #endregion

        #region Private Methods
        private void init()
        {
            DisplayName = "کتابخانه نکات کوتاه روز";
            DailyShortTipList = new ObservableCollection<SummeryDailyShortTip>();
            LibraryNameList = new ObservableCollection<CrudLibrary>();
            SelectedLibraryName=new CrudLibrary();
        }

        protected override void OnRequestClose()
        {
            base.OnRequestClose();
            controller.Close(this);
        }

        private void showDateFilter()
        {

        }
        private void showLibrary()
        {
            libraryService.ShowSelectedDailyLibrary((res, exp) =>
            {
                HideBusyIndicator();
                if (exp == null)
                {
                    DailyShortTipList=new ObservableCollection<SummeryDailyShortTip>(res);
                }
                else
                {
                    controller.HandleException(exp);
                }
            }, SelectedLibraryName);
        }
        private void create()
        {
            controller.ShowDailyShortTipsLibraryView();
        }

        public void modify()
        {
            controller.ShowDailyShortTipsLibraryView();
        }
        public void delete()
        {
            //libraryService.DeleteDailyShortTip(
            //    (res, exp) =>
            //    {
            //        HideBusyIndicator();
            //        if (exp == null)
            //        {
            //            selectedLibraryName=new CrudLibrary();
            //        }
            //    },SelectedLibraryName);
        }
        #endregion

        #region Public Methods

        public void Load()
        {
            libraryService.GetAllDailyShortTipList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        DailyShortTipList = new ObservableCollection<SummeryDailyShortTip>(res);
                    }
                    else controller.HandleException(exp);
                });
            libraryService.GetAllDailyLibraryNameList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        LibraryNameList = new ObservableCollection<CrudLibrary>(res);
                    }
                    else controller.HandleException(exp);
                });
        }
        #endregion
    }
}
