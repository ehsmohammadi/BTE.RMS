using System.Collections.ObjectModel;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Presentation.Logic.WPF.Controller;
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
        private ObservableCollection<CrudTransaction> registerReceipts;

        public ObservableCollection<CrudTransaction> RegisterReceipts
        {
            get { return registerReceipts; }
            set { this.SetField(p => p.RegisterReceipts, ref registerReceipts, value); }
        }

        private CrudTransaction selectedRegisterReceipt;

        public CrudTransaction SelectedRegisterReceipt
        {
            get { return selectedRegisterReceipt; }
            set
            {
                this.SetField(p => p.SelectedRegisterReceipt, ref  selectedRegisterReceipt, value);
            }
        }
        private ObservableCollection<CrudTransaction> registerPayments;

        public ObservableCollection<CrudTransaction> RegisterPayments
        {
            get { return registerPayments; }
            set { this.SetField(p => p.RegisterPayments, ref registerPayments, value); }
        }
        private CrudTransaction selectedRegisterPayment;

        public CrudTransaction SelectedRegisterPayment
        {
            get { return selectedRegisterPayment; }
            set { this.SetField(p => p.SelectedRegisterPayment, ref selectedRegisterPayment, value); }
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
            RegisterPayments=new ObservableCollection<CrudTransaction>();
            registerReceipts=new ObservableCollection<CrudTransaction>();
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
            registerReceiptAndPaymentListService.GetAllRegisterReceiptList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        RegisterReceipts =new ObservableCollection<CrudTransaction>(res);
                    }
                    else controller.HandleException(exp);
                });
            registerReceiptAndPaymentListService.GetAllRegisterPaymentList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        RegisterPayments = new ObservableCollection<CrudTransaction>(res);
                    }
                    else controller.HandleException(exp);
                });
        }
        #endregion
    }
}
