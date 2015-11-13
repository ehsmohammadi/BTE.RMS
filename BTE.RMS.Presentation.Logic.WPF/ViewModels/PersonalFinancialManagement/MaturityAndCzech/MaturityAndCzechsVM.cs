using System.Collections.ObjectModel;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Interface.Contract.PersonalFinancialManagement.MaturityAndCzech;
using BTE.RMS.Presentation.Logic.WPF.Controller;
using BTE.RMS.Presentation.Logic.WPF.Wrappers;
using BTE.RMS.Presentation.Logic.WPF.Wrappers.PersonalFinancialManagement.MaturityAndCzechs;

namespace BTE.RMS.Presentation.Logic.WPF.ViewModels
{
    public class MaturityAndCzechsVM : WorkspaceViewModel
    {
        #region Fields
        private readonly IRMSController controller;
        private readonly IMaturityAndCzechsServiceWrapper maturityAndCzechsService;

        #endregion

        #region Properties & BackFields

        private ObservableCollection<SummeryIssuedCzech> issuedCzeches;

        public ObservableCollection<SummeryIssuedCzech> IssuedCzeches
        {
            get { return issuedCzeches; }
            set { this.SetField(p=>p.IssuedCzeches,ref issuedCzeches,value);}
        }

        private SummeryIssuedCzech selectedIssuedCzech;

        public SummeryIssuedCzech SelectedIssuedCzech
        {
            get { return selectedIssuedCzech; }
            set
            {
                this.SetField(p => p.SelectedIssuedCzech, ref selectedIssuedCzech, value);
            }
        }

        private ObservableCollection<SummeryCzechsReceived> czechsReceiveds;

        public ObservableCollection<SummeryCzechsReceived> CzechsReceiveds
        {
            get { return czechsReceiveds; }
            set
            {
                this.SetField(p=>p.CzechsReceiveds,ref czechsReceiveds,value);
            }
        }

        private SummeryCzechsReceived selectedCzechsReceived;

        public SummeryCzechsReceived SelectedCzechsReceived
        {
            get { return selectedCzechsReceived; }
            set
            {
                this.SetField(p=>p.SelectedCzechsReceived,ref selectedCzechsReceived,value);
            }
        }

        private ObservableCollection<SummeryDemands> demandses;

        public ObservableCollection<SummeryDemands> Demandses
        {
            get { return demandses; }
            set { this.SetField(p=>p.Demandses,ref demandses,value);}
        }

        private SummeryDemands selectedDemands;

        public SummeryDemands SelectedDemands
        {
            get { return selectedDemands; }
            set
            {
                this.SetField(p=>p.SelectedDemands,ref selectedDemands,value);
            }
        }

        private ObservableCollection<SummeryDebts> debtses;

        public ObservableCollection<SummeryDebts> Debtses
        {
            get { return debtses; }
            set { this.SetField(p=>p.Debtses,ref debtses,value);}
        }

        private SummeryDebts selectedDebts;

        public SummeryDebts SelectedDebts
        {
            get { return selectedDebts; }
            set { this.SetField(p=>p.SelectedDebts,ref selectedDebts,value);}
        }

        private ObservableCollection<SummeryOtherCommitments> otherCommitmentses;

        public ObservableCollection<SummeryOtherCommitments> OtherCommitmentses
        {
            get { return otherCommitmentses; }
            set { this.SetField(p=>p.OtherCommitmentses,ref otherCommitmentses,value);}
        }

        private SummeryOtherCommitments selectedOtherCommitments;

        public SummeryOtherCommitments SelectedOtherCommitments
        {
            get { return selectedOtherCommitments; }
            set
            {
                this.SetField(p => p.SelectedOtherCommitments, ref selectedOtherCommitments, value);
            }
        }
        #endregion

        #region Constructors

        public MaturityAndCzechsVM()
        {
            init();
        }

        public MaturityAndCzechsVM(IRMSController controller,IMaturityAndCzechsServiceWrapper maturityAndCzechsService)
        {
            this.controller = controller;
            this.maturityAndCzechsService = maturityAndCzechsService;
            init();
        }

        #endregion

        #region Private Methods

        public void init()
        {
            DisplayName = "سررسید تهدات و چک ها";
            IssuedCzeches=new ObservableCollection<SummeryIssuedCzech>();
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
            maturityAndCzechsService.GetAllIssuedCzechList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        IssuedCzeches = new ObservableCollection<SummeryIssuedCzech>(res);
                    }
                    else controller.HandleException(exp);
                });
            maturityAndCzechsService.GetAllCzechsReceivedList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        CzechsReceiveds = new ObservableCollection<SummeryCzechsReceived>(res);
                    }
                    else controller.HandleException(exp);
                });
            maturityAndCzechsService.GetAllDemandList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        Demandses = new ObservableCollection<SummeryDemands>(res);
                    }
                    else controller.HandleException(exp);
                });
            maturityAndCzechsService.GetAllDebtList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        Debtses = new ObservableCollection<SummeryDebts>(res);
                    }
                    else controller.HandleException(exp);
                });
            maturityAndCzechsService.GetAllOtherCommitmentsList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        OtherCommitmentses = new ObservableCollection<SummeryOtherCommitments>(res);
                    }
                    else controller.HandleException(exp);
                });
        }
        #endregion
    }
}
