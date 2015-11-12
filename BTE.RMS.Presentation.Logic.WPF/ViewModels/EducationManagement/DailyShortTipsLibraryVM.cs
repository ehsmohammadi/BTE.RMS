using System.Collections.ObjectModel;
using BTE.Presentation;
using BTE.RMS.Interface.Contract.EducationManagement;
using BTE.RMS.Presentation.Logic.WPF.Controller;
using BTE.RMS.Presentation.Logic.WPF.Wrappers.EducationManagement.DailyShortTipsLibrary;

namespace BTE.RMS.Presentation.Logic.WPF.ViewModels
{
    public class DailyShortTipsLibraryVM:WorkspaceViewModel
    {
        private readonly IRMSController controller;
        private readonly IDailyShortTipsLibraryServiceWrapper dailyShortTipsLibraryService;

        #region Fields

        #endregion

        #region Properties & BackFields

        private ObservableCollection<DailyShortTips> dailyShortTipsLibraries;

        public ObservableCollection<DailyShortTips> DailyShortTipsLibraries
        {
            get { return dailyShortTipsLibraries; }
            set
            {
                this.SetField(p => p.DailyShortTipsLibraries, ref dailyShortTipsLibraries, value);
            }
        }

        private DailyShortTips selectedDailyShortTipsLibrary;

        public DailyShortTips SelectedDailyShortTipsLibrary
        {
            get { return selectedDailyShortTipsLibrary; }
            set
            {
                this.SetField(p => p.SelectedDailyShortTipsLibrary, ref selectedDailyShortTipsLibrary, value);
            }
        }

        #endregion

        #region Constructors

        public DailyShortTipsLibraryVM()
        {
            init();
        }
        public DailyShortTipsLibraryVM(IRMSController controller,IDailyShortTipsLibraryServiceWrapper dailyShortTipsLibraryService)
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
            DailyShortTipsLibraries = new ObservableCollection<DailyShortTips>();
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
                        DailyShortTipsLibraries = new ObservableCollection<DailyShortTips>(res);
                    }
                    else controller.HandleException(exp);
                });
        }
        #endregion
    }
}
