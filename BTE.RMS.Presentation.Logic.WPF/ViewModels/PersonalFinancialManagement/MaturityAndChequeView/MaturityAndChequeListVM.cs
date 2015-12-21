using System.Collections.ObjectModel;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Presentation.Logic.WPF.Controller;
using BTE.RMS.Presentation.Logic.WPF.Wrappers;

namespace BTE.RMS.Presentation.Logic.WPF.ViewModels
{
    public class MaturityAndChequeListVM : WorkspaceViewModel
    {
        #region Fields
        private readonly IRMSController controller;
        private readonly IMaturityAndChequeServiceWrapper maturityAndChequeService;

        #endregion

        #region Properties & BackFields

        private ObservableCollection<Cheque> paymentCheques;

        public ObservableCollection<Cheque> PaymentCheques
        {
            get { return paymentCheques; }
            set { this.SetField(p => p.PaymentCheques, ref paymentCheques, value); }
        }

        private Cheque selectedPaymentCheque;

        public Cheque SelectedPaymentCheque
        {
            get { return selectedPaymentCheque; }
            set
            {
                this.SetField(p => p.selectedPaymentCheque, ref selectedPaymentCheque, value);
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

        private CommandViewModel createCmd;
        public CommandViewModel CreateCmd
        {
            get
            {
                if (createCmd == null)
                {
                    createCmd = new CommandViewModel("سر رسید مالی جدید", new DelegateCommand(create));
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

        public MaturityAndChequeListVM()
        {
            init();
        }

        public MaturityAndChequeListVM(IRMSController controller, IMaturityAndChequeServiceWrapper maturityAndChequeService)
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
            PaymentCheques = new ObservableCollection<Cheque>();
        }
        protected override void OnRequestClose()
        {
            base.OnRequestClose();
            controller.Close(this);
        }

        private void create()
        {
            controller.ShowMaturityAndChequeView();
        }

        public void modify()
        {
            controller.ShowMaturityAndChequeView();
        }
        public void delete()
        {
            controller.ShowMaturityAndChequeView();
        }
        #endregion

        #region Public Methods

        public void Load()
        {
            maturityAndChequeService.GetAllPaymentChequeList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        PaymentCheques = new ObservableCollection<Cheque>(res);
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
