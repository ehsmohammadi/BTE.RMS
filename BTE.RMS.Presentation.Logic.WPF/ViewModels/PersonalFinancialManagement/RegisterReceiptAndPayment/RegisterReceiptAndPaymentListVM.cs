using System.Collections.ObjectModel;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Presentation.Logic.Controller;
using BTE.RMS.Presentation.Logic.WPF.Wrappers;

namespace BTE.RMS.Presentation.Logic.WPF.ViewModels
{
    public class RegisterReceiptAndPaymentListVM : WorkspaceViewModel
    {

        #region Fields
        private readonly IRMSController controller;
        private readonly IRegisterReceiptAndPaymentListServiceWrapper registerReceiptAndPaymentListService;

        #endregion

        #region Properties & BackFields

        /// <summary>
        /// Register Download and Register Pay Lists
        /// </summary>
        private ObservableCollection<ReceiptAndPayment> receipts;

        public ObservableCollection<ReceiptAndPayment> Receipts
        {
            get { return receipts; }
            set { this.SetField(p => p.Receipts, ref receipts, value); }
        }

        private ReceiptAndPayment selectedReceipt;

        public ReceiptAndPayment SelectedReceipt
        {
            get { return selectedReceipt; }
            set
            {
                this.SetField(p => p.SelectedReceipt, ref  selectedReceipt, value);
            }
        }
        private ObservableCollection<ReceiptAndPayment> payments;

        public ObservableCollection<ReceiptAndPayment> Payments
        {
            get { return payments; }
            set { this.SetField(p => p.Payments, ref payments, value); }
        }
        private ReceiptAndPayment selectedPayment;

        public ReceiptAndPayment SelectedPayment
        {
            get { return selectedPayment; }
            set { this.SetField(p => p.SelectedPayment, ref selectedPayment, value); }
        }
        private CommandViewModel createCmd;
        public CommandViewModel CreateCmd
        {
            get
            {
                if (createCmd == null)
                {
                    createCmd = new CommandViewModel("دریافت/پرداخت جدید", new DelegateCommand(create));
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

        public RegisterReceiptAndPaymentListVM()
        {
            init();
        }
        public RegisterReceiptAndPaymentListVM(IRMSController controller, IRegisterReceiptAndPaymentListServiceWrapper registerReceiptAndPaymentListService)
        {
            this.controller = controller;
            this.registerReceiptAndPaymentListService = registerReceiptAndPaymentListService;
            init();
        }

        #endregion

        #region Private Methods

        private void init()
        {
            DisplayName = "ثبت دانلود ها و دریافت ها";
            Payments=new ObservableCollection<ReceiptAndPayment>();
            Receipts=new ObservableCollection<ReceiptAndPayment>();
        }

        protected override void OnRequestClose()
        {
            base.OnRequestClose();
            controller.Close(this);
        }

        private void create()
        {
            controller.ShowRegisterReceiptAndPaymentView();
        }

        public void modify()
        {
            controller.ShowRegisterReceiptAndPaymentView();
        }
        public void delete()
        {
            controller.ShowRegisterReceiptAndPaymentView();
        }
        #endregion

        #region Public Methods

        public void Load()
        {
            registerReceiptAndPaymentListService.GetAllReceiptList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        Receipts =new ObservableCollection<ReceiptAndPayment>(res);
                    }
                    else controller.HandleException(exp);
                });
            registerReceiptAndPaymentListService.GetAllPaymentList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        Payments = new ObservableCollection<ReceiptAndPayment>(res);
                    }
                    else controller.HandleException(exp);
                });
        }
        #endregion
    }
}
