using System.Collections.ObjectModel;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Presentation.Logic.WPF.Controller;
using BTE.RMS.Presentation.Logic.WPF.Wrappers;

namespace BTE.RMS.Presentation.Logic.WPF.ViewModels
{
    public class PrayerTimeSettingsVM:WorkspaceViewModel
    {
        

        #region Fields
        private readonly IRMSController controller;

        #endregion

        #region Properties & BackFields

        private ObservableCollection<CrudCity> citySettings;

        private ObservableCollection<CrudCity> CitySettings
        {
            get { return citySettings; }
            set { this.SetField(p=>p.CitySettings,ref citySettings,value);}
        }

        private CrudCity selectedCitySetting;

        public CrudCity SelectedCitySetting
        {
            get { return selectedCitySetting; }
            set { this.SetField(p => p.SelectedCitySetting, ref selectedCitySetting, value); }
        }


        #endregion

        #region Constructors

        public PrayerTimeSettingsVM()
        {
            init();
        }
        public PrayerTimeSettingsVM(IRMSController controller)
        {
            this.controller = controller;

        }

        #endregion

        #region Private Methods

        private void init()
        {
            DisplayName = "تنظیمات اوقات شرعی شهر ها";
            CitySettings=new ObservableCollection<CrudCity>();
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
            //prayerTimeSettingsService.CreateCityScaleService(
            //    (res, exp) =>
            //    {
            //        HideBusyIndicator();
            //        if (exp == null)
            //        {
            //            CitySettings=new ObservableCollection<CrudCity>(res);
            //        }
            //        else controller.HandleException(exp);
            //    });
        }
        #endregion
    }
}
