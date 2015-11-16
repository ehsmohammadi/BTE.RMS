using System.Collections.ObjectModel;
using BTE.Presentation;
using BTE.RMS.Interface.Contract.EducationManagement;
using BTE.RMS.Presentation.Logic.WPF.Controller;
using BTE.RMS.Presentation.Logic.WPF.Wrappers.EducationManagement.DailyShortTipsLibrary;

namespace BTE.RMS.Presentation.Logic.WPF.ViewModels
{
    public class DailyShortTipLibraryVM:WorkspaceViewModel
    {
        private readonly IRMSController controller;
        private readonly IDailyShortTipsLibraryServiceWrapper dailyShortTipsLibraryService;

        #region Fields

        #endregion

        #region Properties & BackFields

        private ObservableCollection<DailyShortTip> dailyShortTipsLibraries;

        public ObservableCollection<DailyShortTip> DailyShortTipsLibraries
        {
            get { return dailyShortTipsLibraries; }
            set
            {
                this.SetField(p => p.DailyShortTipsLibraries, ref dailyShortTipsLibraries, value);
            }
        }

        private DailyShortTip selectedDailyShortTipsLibrary;

        public DailyShortTip SelectedDailyShortTipsLibrary
        {
            get { return selectedDailyShortTipsLibrary; }
            set
            {
                this.SetField(p => p.SelectedDailyShortTipsLibrary, ref selectedDailyShortTipsLibrary, value);
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
            DailyShortTipsLibraries = new ObservableCollection<DailyShortTip>();
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
                        DailyShortTipsLibraries = new ObservableCollection<DailyShortTip>(res);
                    }
                    else controller.HandleException(exp);
                });
        }
        #endregion
    }
}
