using System.Collections.ObjectModel;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Interface.Contract.PersonalFinancialManagement.MaturityAndCzech;
using BTE.RMS.Presentation.Logic.WPF.Controller;
using BTE.RMS.Presentation.Logic.WPF.Wrappers;
using BTE.RMS.Presentation.Logic.WPF.Wrappers.PersonalFinancialManagement.MaturityAndCzechs;

namespace BTE.RMS.Presentation.Logic.WPF.ViewModels
{
    public class MaturityAndChequeVM : WorkspaceViewModel
    {
        #region Fields
        private readonly IRMSController controller;
        private readonly IMaturityAndChequeServiceWrapper maturityAndChequeService;

        #endregion

        #region Properties & BackFields

        private ObservableCollection<ExportAndReceivedCheque> exportCheques;

        public ObservableCollection<ExportAndReceivedCheque> ExportCheques
        {
            get { return exportCheques; }
            set { this.SetField(p => p.ExportCheques, ref exportCheques, value); }
        }

        private ExportAndReceivedCheque selectedExportCheque;

        public ExportAndReceivedCheque SelectedExportCheque
        {
            get { return selectedExportCheque; }
            set
            {
                this.SetField(p => p.selectedExportCheque, ref selectedExportCheque, value);
            }
        }

        private ObservableCollection<ExportAndReceivedCheque> receivedCheques;

        public ObservableCollection<ExportAndReceivedCheque> ReceivedCheques
        {
            get { return receivedCheques; }
            set
            {
                this.SetField(p => p.ReceivedCheques, ref receivedCheques, value);
            }
        }

        private ExportAndReceivedCheque selectedReceivedCheque;

        public ExportAndReceivedCheque SelectedReceivedCheque
        {
            get { return selectedReceivedCheque; }
            set
            {
                this.SetField(p => p.SelectedReceivedCheque, ref selectedReceivedCheque, value);
            }
        }

        private ObservableCollection<OtherFinancialState> demands;

        public ObservableCollection<OtherFinancialState> Demands
        {
            get { return demands; }
            set { this.SetField(p=>p.Demands,ref demands,value);}
        }

        private OtherFinancialState selectedDemand;

        public OtherFinancialState SelectedDemand
        {
            get { return selectedDemand; }
            set
            {
                this.SetField(p=>p.SelectedDemand,ref selectedDemand,value);
            }
        }

        private ObservableCollection<OtherFinancialState> debts;

        public ObservableCollection<OtherFinancialState> Debts
        {
            get { return debts; }
            set { this.SetField(p=>p.Debts,ref debts,value);}
        }

        private OtherFinancialState selectedDebt;

        public OtherFinancialState SelectedDebt
        {
            get { return selectedDebt; }
            set { this.SetField(p=>p.SelectedDebt,ref selectedDebt,value);}
        }

        private ObservableCollection<OtherFinancialState> otherCommitments;

        public ObservableCollection<OtherFinancialState> OtherCommitments
        {
            get { return otherCommitments; }
            set { this.SetField(p=>p.OtherCommitments,ref otherCommitments,value);}
        }

        private OtherFinancialState selectedOtherCommitment;

        public OtherFinancialState SelectedOtherCommitment
        {
            get { return selectedOtherCommitment; }
            set
            {
                this.SetField(p => p.SelectedOtherCommitment, ref selectedOtherCommitment, value);
            }
        }
        #endregion

        #region Constructors

        public MaturityAndChequeVM()
        {
            init();
        }

        public MaturityAndChequeVM(IRMSController controller, IMaturityAndChequeServiceWrapper maturityAndChequeService)
        {
            this.controller = controller;
            this.maturityAndChequeService = maturityAndChequeService;
            init();
        }

        #endregion

        #region Private Methods

        public void init()
        {
            DisplayName = "سررسید تهدات و چک ها";
            ReceivedCheques = new ObservableCollection<ExportAndReceivedCheque>();
            ExportCheques = new ObservableCollection<ExportAndReceivedCheque>();
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
            maturityAndChequeService.GetAllExportChequeList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        ExportCheques = new ObservableCollection<ExportAndReceivedCheque>(res);
                    }
                    else controller.HandleException(exp);
                });
            maturityAndChequeService.GetAllReceivedChequeList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        ReceivedCheques = new ObservableCollection<ExportAndReceivedCheque>(res);
                    }
                    else controller.HandleException(exp);
                });
            maturityAndChequeService.GetAllDemandList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        Demands = new ObservableCollection<OtherFinancialState>(res);
                    }
                    else controller.HandleException(exp);
                });
            maturityAndChequeService.GetAllDebtList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        Debts = new ObservableCollection<OtherFinancialState>(res);
                    }
                    else controller.HandleException(exp);
                });
            maturityAndChequeService.GetAllOtherCommitmentsList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        OtherCommitments = new ObservableCollection<OtherFinancialState>(res);
                    }
                    else controller.HandleException(exp);
                });
        }
        #endregion
    }
}
