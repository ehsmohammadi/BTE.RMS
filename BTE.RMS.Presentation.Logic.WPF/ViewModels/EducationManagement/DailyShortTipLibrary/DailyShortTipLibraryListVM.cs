using System.Collections.ObjectModel;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Presentation.Logic.WPF.Controller;
using BTE.RMS.Presentation.Logic.WPF.Wrappers;

namespace BTE.RMS.Presentation.Logic.WPF.ViewModels
{
    public class DailyShortTipLibraryListVM:WorkspaceViewModel
    {


        #region Fields
        private readonly IRMSController controller;
        private readonly IDailyShortTipsLibraryServiceWrapper dailyShortTipsLibraryService;
        #endregion

        #region Properties & BackFields

        private ObservableCollection<DailyShortTip> dailyShortTips;

        public ObservableCollection<DailyShortTip> DailyShortTips
        {
            get { return dailyShortTips; }
            set
            {
                this.SetField(p => p.DailyShortTips, ref dailyShortTips, value);
            }
        }

        private DailyShortTip selectedDailyShortTip;

        public DailyShortTip SelectedDailyShortTip
        {
            get { return selectedDailyShortTip; }
            set
            {
                this.SetField(p => p.SelectedDailyShortTip, ref selectedDailyShortTip, value);
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
        public DailyShortTipLibraryListVM(IRMSController controller, IDailyShortTipsLibraryServiceWrapper dailyShortTipsLibraryService)
        {
            init();
            this.controller = controller;
            this.dailyShortTipsLibraryService = dailyShortTipsLibraryService;
        }


        #endregion

        #region Private Methods
        private void init()
        {
            DisplayName = "حساب های مالی";
            dailyShortTips = new ObservableCollection<DailyShortTip>();
        }

        protected override void OnRequestClose()
        {
            base.OnRequestClose();
            controller.Close(this);
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
            controller.ShowDailyShortTipsLibraryView();
        }
        #endregion

        #region Public Methods

        public void Load()
        {
            dailyShortTipsLibraryService.GetAllDailyShortTipsList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        DailyShortTips = new ObservableCollection<DailyShortTip>(res);
                    }
                    else controller.HandleException(exp);
                });
        }
        #endregion
    }
}
