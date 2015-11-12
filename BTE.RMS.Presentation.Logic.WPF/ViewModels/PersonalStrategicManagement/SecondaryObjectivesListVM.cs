using System.Collections.ObjectModel;
using BTE.Presentation;
using BTE.RMS.Interface.Contract.PersonalStrategicManagement.SecondaryObjectives;
using BTE.RMS.Presentation.Logic.WPF.Controller;
using BTE.RMS.Presentation.Logic.WPF.Wrappers.PersonalStrategicManagement.SecondaryObjectivesList;

namespace BTE.RMS.Presentation.Logic.WPF.ViewModels
{
    public class SecondaryObjectivesListVM:WorkspaceViewModel
    {


        #region Fields
        private readonly IRMSController controller;
        private readonly ISecondaryObjectivesServiceWrapper secondaryObjectivesService;

        #endregion

        #region Properties & BackFields

        private ObservableCollection<SummerySecondaryObjectives> secondaryObjectiveses;

        public ObservableCollection<SummerySecondaryObjectives> SecondaryObjectiveses
        {
            get { return secondaryObjectiveses; }
            set { this.SetField(p=>p.SecondaryObjectiveses,ref secondaryObjectiveses,value);}
        }

        private SummerySecondaryObjectives selectedSecondaryObjectives;

        public SummerySecondaryObjectives SelectedSecondaryObjectives
        {
            get { return selectedSecondaryObjectives; }
            set
            {
                this.SetField(p=>p.SelectedSecondaryObjectives,ref selectedSecondaryObjectives,value);
                if(selectedSecondaryObjectives==null) return;
            }
        }

        #endregion

        #region Constructors
        public SecondaryObjectivesListVM(IRMSController controller,ISecondaryObjectivesServiceWrapper secondaryObjectivesService)
        {
            this.controller = controller;
            this.secondaryObjectivesService = secondaryObjectivesService;
            init();
        }

        public SecondaryObjectivesListVM()
        {
            init();
        }
        #endregion

        #region Private Methods
        private void init()
        {
            DisplayName = "اهداف فرعی";
            SecondaryObjectiveses=new ObservableCollection<SummerySecondaryObjectives>();
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
            secondaryObjectivesService.GetAllSecondaryObjectives(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        SecondaryObjectiveses = new ObservableCollection<SummerySecondaryObjectives>(res);
                    }
                    else controller.HandleException(exp);
                });
        }

        #endregion
    }
}
