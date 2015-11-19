using System.Collections.ObjectModel;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Presentation.Logic.WPF.Controller;
using BTE.RMS.Presentation.Logic.WPF.Wrappers;

namespace BTE.RMS.Presentation.Logic.WPF.ViewModels
{
    public class DailyShortTipLibraryVM:WorkspaceViewModel
    {
        private readonly IRMSController controller;
        private readonly IDailyShortTipsLibraryServiceWrapper dailyShortTipsLibraryService;

        #region Fields

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

        #endregion

        #region Constructors

        public DailyShortTipLibraryVM()
        {
            init();
        }
        public DailyShortTipLibraryVM(IRMSController controller,IDailyShortTipsLibraryServiceWrapper dailyShortTipsLibraryService)
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
