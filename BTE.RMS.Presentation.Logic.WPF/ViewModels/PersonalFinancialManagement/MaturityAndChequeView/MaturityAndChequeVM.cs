using System.Collections.ObjectModel;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Presentation.Logic.WPF.Controller;
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

        private ObservableCollection<Cheque> exportCheques;

        public ObservableCollection<Cheque> ExportCheques
        {
            get { return exportCheques; }
            set { this.SetField(p => p.ExportCheques, ref exportCheques, value); }
        }

        private Cheque selectedExportCheque;

        public Cheque SelectedExportCheque
        {
            get { return selectedExportCheque; }
            set
            {
                this.SetField(p => p.selectedExportCheque, ref selectedExportCheque, value);
            }
        }

        private ObservableCollection<Cheque> receivedCheques;

        public ObservableCollection<Cheque> ReceivedCheques
        {
            get { return receivedCheques; }
            set
            {
                this.SetField(p => p.ReceivedCheques, ref receivedCheques, value);
            }
        }

        private Cheque selectedReceivedCheque;

        public Cheque SelectedReceivedCheque
        {
            get { return selectedReceivedCheque; }
            set
            {
                this.SetField(p => p.SelectedReceivedCheque, ref selectedReceivedCheque, value);
            }
        }

        private ObservableCollection<FinancialCommitments> demands;

        public ObservableCollection<FinancialCommitments> Demands
        {
            get { return demands; }
            set { this.SetField(p=>p.Demands,ref demands,value);}
        }

        private FinancialCommitments selectedDemand;

        public FinancialCommitments SelectedDemand
        {
            get { return selectedDemand; }
            set
            {
                this.SetField(p=>p.SelectedDemand,ref selectedDemand,value);
            }
        }

        private ObservableCollection<FinancialCommitments> debts;

        public ObservableCollection<FinancialCommitments> Debts
        {
            get { return debts; }
            set { this.SetField(p=>p.Debts,ref debts,value);}
        }

        private FinancialCommitments selectedDebt;

        public FinancialCommitments SelectedDebt
        {
            get { return selectedDebt; }
            set { this.SetField(p=>p.SelectedDebt,ref selectedDebt,value);}
        }

        private ObservableCollection<FinancialCommitments> otherCommitments;

        public ObservableCollection<FinancialCommitments> OtherCommitments
        {
            get { return otherCommitments; }
            set { this.SetField(p=>p.OtherCommitments,ref otherCommitments,value);}
        }

        private FinancialCommitments selectedOtherCommitment;

        public FinancialCommitments SelectedOtherCommitment
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
            ReceivedCheques = new ObservableCollection<Cheque>();
            ExportCheques = new ObservableCollection<Cheque>();
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
                        ExportCheques = new ObservableCollection<Cheque>(res);
                    }
                    else controller.HandleException(exp);
                });
            maturityAndChequeService.GetAllReceivedChequeList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        ReceivedCheques = new ObservableCollection<Cheque>(res);
                    }
                    else controller.HandleException(exp);
                });
            maturityAndChequeService.GetAllDemandList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        Demands = new ObservableCollection<FinancialCommitments>(res);
                    }
                    else controller.HandleException(exp);
                });
            maturityAndChequeService.GetAllDebtList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        Debts = new ObservableCollection<FinancialCommitments>(res);
                    }
                    else controller.HandleException(exp);
                });
            maturityAndChequeService.GetAllOtherCommitmentsList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        OtherCommitments = new ObservableCollection<FinancialCommitments>(res);
                    }
                    else controller.HandleException(exp);
                });
        }
        #endregion
    }
}
