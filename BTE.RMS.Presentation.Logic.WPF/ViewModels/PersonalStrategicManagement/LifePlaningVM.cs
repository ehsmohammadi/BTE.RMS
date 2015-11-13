using System.Collections.ObjectModel;
using BTE.Presentation;
using BTE.RMS.Interface.Contract.PersonalStrategicManagement.LifePlaning;
using BTE.RMS.Presentation.Logic.WPF.Controller;
using BTE.RMS.Presentation.Logic.WPF.Wrappers.PersonalStrategicManagement.LifePlaning;

namespace BTE.RMS.Presentation.Logic.WPF.ViewModels
{
    public class LifePlaningVM:WorkspaceViewModel
    {


        #region Fields
        private readonly IRMSController controller;
        private readonly ILifePlaningServiceWrapper lifePlaningService;

        #endregion
        #region Properties & BackFields

        private ObservableCollection<HumanTime> humanTimes;

        public ObservableCollection<HumanTime> HumanTimes
        {
            get { return humanTimes; }
            set { this.SetField(p=>p.HumanTimes,ref humanTimes,value);}
        }

        private HumanTime selectedHumanTime;

        public HumanTime SelectedHumanTime
        {
            get { return selectedHumanTime; }
            set
            {
                this.SetField(p=>p.SelectedHumanTime,ref selectedHumanTime,value);
            }
        }

        private ObservableCollection<My90YearLifePlaning> my90YearLifePlanings;

        public ObservableCollection<My90YearLifePlaning> My90YearLifePlanings
        {
            get { return my90YearLifePlanings; }
            set { this.SetField(p=>p.My90YearLifePlanings,ref my90YearLifePlanings,value);}
        }

        private My90YearLifePlaning selectedMy90YearLifePlaning;

        public My90YearLifePlaning SelectedMy90YearLifePlaning
        {
            get { return selectedMy90YearLifePlaning; }
            set
            {
                this.SetField(p=>p.SelectedMy90YearLifePlaning,ref selectedMy90YearLifePlaning,value);
            }
        }
        #endregion

        #region Constructors

        public LifePlaningVM()
        {
            init();
        }
        public LifePlaningVM(IRMSController controller,ILifePlaningServiceWrapper lifePlaningService)
        {
            this.controller = controller;
            this.lifePlaningService = lifePlaningService;
        }

        #endregion

        #region Private Methods
        private void init()
        {
            DisplayName = "برنامه ریزی عمر";
            humanTimes=new ObservableCollection<HumanTime>();
            my90YearLifePlanings = new ObservableCollection<My90YearLifePlaning>();
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
            lifePlaningService.GetAllHumanTimes(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        HumanTimes = new ObservableCollection<HumanTime>(res);
                    }
                    else controller.HandleException(exp);
                });
            lifePlaningService.GetAllMy90YearLifePlanings(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        My90YearLifePlanings = new ObservableCollection<My90YearLifePlaning>(res);
                    }
                    else controller.HandleException(exp);
                });
        }
        #endregion
    }
}
