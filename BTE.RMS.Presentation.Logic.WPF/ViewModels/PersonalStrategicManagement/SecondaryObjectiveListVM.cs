using System.Collections.ObjectModel;
using BTE.Presentation;
using BTE.RMS.Interface.Contract.PersonalStrategicManagement.SecondaryObjectives;
using BTE.RMS.Presentation.Logic.WPF.Controller;
using BTE.RMS.Presentation.Logic.WPF.Wrappers.PersonalStrategicManagement.SecondaryObjectivesList;

namespace BTE.RMS.Presentation.Logic.WPF.ViewModels
{
    public class SecondaryObjectiveListVM:WorkspaceViewModel
    {


        #region Fields
        private readonly IRMSController controller;
        private readonly ISecondaryObjectiveServiceWrapper secondaryObjectiveService;

        #endregion

        #region Properties & BackFields

        private ObservableCollection<SummerySecondaryObjective> secondaryObjectives;

        public ObservableCollection<SummerySecondaryObjective> SecondaryObjectives
        {
            get { return secondaryObjectives; }
            set { this.SetField(p=>p.SecondaryObjectives,ref secondaryObjectives,value);}
        }

        private SummerySecondaryObjective selectedSecondaryObjective;

        public SummerySecondaryObjective SelectedSecondaryObjective
        {
            get { return selectedSecondaryObjective; }
            set
            {
                this.SetField(p=>p.SelectedSecondaryObjective,ref selectedSecondaryObjective,value);
            }
        }

        #endregion

        #region Constructors
        public SecondaryObjectiveListVM(IRMSController controller,ISecondaryObjectiveServiceWrapper secondaryObjectiveService)
        {
            this.controller = controller;
            this.secondaryObjectiveService = secondaryObjectiveService;
            init();
        }

        public SecondaryObjectiveListVM()
        {
            init();
        }
        #endregion

        #region Private Methods
        private void init()
        {
            DisplayName = "اهداف فرعی";
            SecondaryObjectives=new ObservableCollection<SummerySecondaryObjective>();
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
            secondaryObjectiveService.GetAllSecondaryObjectives(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        SecondaryObjectives = new ObservableCollection<SummerySecondaryObjective>(res);
                    }
                    else controller.HandleException(exp);
                });
        }

        #endregion
    }
}
