using System.Collections.ObjectModel;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Presentation.Logic.Controller;
using BTE.RMS.Presentation.Logic.WPF.Wrappers;

namespace BTE.RMS.Presentation.Logic.WPF.ViewModels
{
    public class PrayerTimesVM:WorkspaceViewModel
    {


        #region Fields
        private readonly IRMSController controller;
        private readonly IPrayerTimeServiceWrapper prayerTimeService;

        #endregion
        #region Properties & BackFields

        private ObservableCollection<PrayerTimes> prayerTimeses;

        public ObservableCollection<PrayerTimes> PrayerTimeses
        {
            get { return prayerTimeses; }
            set { this.SetField(p=>p.PrayerTimeses,ref prayerTimeses,value);}
        }

        private PrayerTimes selectedPrayerTimes;

        public PrayerTimes SelectedPrayerTimes
        {
            get { return selectedPrayerTimes; }
            set { this.SetField(p=>p.SelectedPrayerTimes,ref selectedPrayerTimes,value);}
        }

        #endregion

        #region Constructors

        public PrayerTimesVM()
        {
            init();
        }
        public PrayerTimesVM(IRMSController controller,IPrayerTimeServiceWrapper prayerTimeService)
        {
            this.controller = controller;
            this.prayerTimeService = prayerTimeService;
        }

        #endregion

        #region Private Methods
        private void init()
        {
            DisplayName = "محاسبات اوقات شرعی";
            PrayerTimeses=new ObservableCollection<PrayerTimes>();
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
            prayerTimeService.GetAllPrayerTimeList(
                (res, exp) => 
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        PrayerTimeses = new ObservableCollection<PrayerTimes>(res);
                    }
                    else controller.HandleException(exp);
                });
        }
        #endregion
    }
}
