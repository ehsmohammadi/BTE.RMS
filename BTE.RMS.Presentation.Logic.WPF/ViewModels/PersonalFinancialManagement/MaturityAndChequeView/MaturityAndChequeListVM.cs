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

        private ObservableCollection<SummeryCheque> paymentCheques;

        public ObservableCollection<SummeryCheque> PaymentCheques
        {
            get { return paymentCheques; }
            set { this.SetField(p => p.PaymentCheques, ref paymentCheques, value); }
        }

        private SummeryCheque selectedPaymentCheque;

        public SummeryCheque SelectedPaymentCheque
        {
            get { return selectedPaymentCheque; }
            set
            {
                this.SetField(p => p.selectedPaymentCheque, ref selectedPaymentCheque, value);
            }
        }

        private ObservableCollection<SummeryCheque> receivedCheques;

        public ObservableCollection<SummeryCheque> ReceivedCheques
        {
            get { return receivedCheques; }
            set
            {
                this.SetField(p => p.ReceivedCheques, ref receivedCheques, value);
            }
        }

        private SummeryCheque selectedReceivedCheque;

        public SummeryCheque SelectedReceivedCheque
        {
            get { return selectedReceivedCheque; }
            set
            {
                this.SetField(p => p.SelectedReceivedCheque, ref selectedReceivedCheque, value);
            }
        }

        private ObservableCollection<SummeryFinancialCommitments> demands;

        public ObservableCollection<SummeryFinancialCommitments> Demands
        {
            get { return demands; }
            set { this.SetField(p=>p.Demands,ref demands,value);}
        }

        private SummeryFinancialCommitments selectedDemand;

        public SummeryFinancialCommitments SelectedDemand
        {
            get { return selectedDemand; }
            set
            {
                this.SetField(p=>p.SelectedDemand,ref selectedDemand,value);
            }
        }

        private ObservableCollection<SummeryFinancialCommitments> debts;

        public ObservableCollection<SummeryFinancialCommitments> Debts
        {
            get { return debts; }
            set { this.SetField(p=>p.Debts,ref debts,value);}
        }

        private SummeryFinancialCommitments selectedDebt;

        public SummeryFinancialCommitments SelectedDebt
        {
            get { return selectedDebt; }
            set { this.SetField(p=>p.SelectedDebt,ref selectedDebt,value);}
        }

        private ObservableCollection<SummeryFinancialCommitments> otherCommitments;

        public ObservableCollection<SummeryFinancialCommitments> OtherCommitments
        {
            get { return otherCommitments; }
            set { this.SetField(p=>p.OtherCommitments,ref otherCommitments,value);}
        }

        private SummeryFinancialCommitments selectedOtherCommitment;

        public SummeryFinancialCommitments SelectedOtherCommitment
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
            ReceivedCheques = new ObservableCollection<SummeryCheque>();
            PaymentCheques = new ObservableCollection<SummeryCheque>();
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
                        PaymentCheques = new ObservableCollection<SummeryCheque>(res);
                    }
                    else controller.HandleException(exp);
                });
            maturityAndChequeService.GetAllReceivedChequeList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        ReceivedCheques = new ObservableCollection<SummeryCheque>(res);
                    }
                    else controller.HandleException(exp);
                });
            maturityAndChequeService.GetAllDemandList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        Demands = new ObservableCollection<SummeryFinancialCommitments>(res);
                    }
                    else controller.HandleException(exp);
                });
            maturityAndChequeService.GetAllDebtList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        Debts = new ObservableCollection<SummeryFinancialCommitments>(res);
                    }
                    else controller.HandleException(exp);
                });
            maturityAndChequeService.GetAllOtherCommitmentsList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        OtherCommitments = new ObservableCollection<SummeryFinancialCommitments>(res);
                    }
                    else controller.HandleException(exp);
                });
        }
        #endregion
    }
}
