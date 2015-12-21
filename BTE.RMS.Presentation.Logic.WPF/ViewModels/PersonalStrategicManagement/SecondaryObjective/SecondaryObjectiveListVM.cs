using System.Collections.ObjectModel;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Presentation.Logic.WPF.Controller;
using BTE.RMS.Presentation.Logic.WPF.Wrappers;

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

        private CommandViewModel createCmd;
        public CommandViewModel CreateCmd
        {
            get
            {
                if (createCmd == null)
                {
                    createCmd = new CommandViewModel("هدف جدید", new DelegateCommand(create));
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
                    modifyCmd = new CommandViewModel("ویرایش", new DelegateCommand(modify));
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
                    deleteCmd = new CommandViewModel("حذف", new DelegateCommand(delete));
                }
                return deleteCmd;
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

        private void create()
        {
            controller.ShowSecondaryObjectiveView();
        }

        public void modify()
        {
            controller.ShowSecondaryObjectiveView();
        }
        public void delete()
        {
            controller.ShowSecondaryObjectiveView();
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
            //secondaryObjectiveService.CreateSecondaryObjectives(
            //    (res, exp) =>
            //    {
            //        HideBusyIndicator();
            //        if (exp == null)
            //        {
            //            SecondaryObjectives = new ObservableCollection<SummerySecondaryObjective>(res);
            //        }
            //        else controller.HandleException(exp);
            //    });
        }

        #endregion
    }
}
