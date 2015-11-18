using System.Collections.ObjectModel;
using System.Data.Odbc;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Presentation.Logic.WPF.Controller;
using BTE.RMS.Presentation.Logic.WPF.Wrappers;

namespace BTE.RMS.Presentation.Logic.WPF.ViewModels
{
    public class RegisterReceiptAndPaymentVM : WorkspaceViewModel
    {

        #region Fields
        private readonly IRMSController controller;
        private readonly IRegisterReceiptAndPaymentListServiceWrapper RegisterReceiptAndPaymentListService;

        #endregion

        #region Properties & BackFields

        /// <summary>
        /// Register Download and Register Pay Lists
        /// </summary>
        private ObservableCollection<RegisterReceiptAndPayment> registerReceipts;

        public ObservableCollection<RegisterReceiptAndPayment> RegisterReceipts
        {
            get { return registerReceipts; }
            set { this.SetField(p => p.RegisterReceipts, ref registerReceipts, value); }
        }

        private RegisterReceiptAndPayment selectedRegisterReceipt;

        public RegisterReceiptAndPayment SelectedRegisterReceipt
        {
            get { return selectedRegisterReceipt; }
            set
            {
                this.SetField(p => p.SelectedRegisterReceipt, ref  selectedRegisterReceipt, value);
            }
        }
        private ObservableCollection<RegisterReceiptAndPayment> registerPayments;

        public ObservableCollection<RegisterReceiptAndPayment> RegisterPayments
        {
            get { return registerPayments; }
            set { this.SetField(p => p.RegisterPayments, ref registerPayments, value); }
        }
        private RegisterReceiptAndPayment selectedRegisterPayment;

        public RegisterReceiptAndPayment SelectedRegisterPayment
        {
            get { return selectedRegisterPayment; }
            set { this.SetField(p => p.SelectedRegisterPayment, ref selectedRegisterPayment, value); }
        }
        #endregion

        #region Constructors

        public RegisterReceiptAndPaymentVM()
        {
            init();
        }
        public RegisterReceiptAndPaymentVM(IRMSController controller, IRegisterReceiptAndPaymentListServiceWrapper RegisterReceiptAndPaymentListService)
        {
            this.controller = controller;
            this.RegisterReceiptAndPaymentListService = RegisterReceiptAndPaymentListService;
            init();
        }

        #endregion

        #region Private Methods

        private void init()
        {
            DisplayName = "ثبت دانلود ها و دریافت ها";
            RegisterPayments=new ObservableCollection<RegisterReceiptAndPayment>();
            registerReceipts=new ObservableCollection<RegisterReceiptAndPayment>();
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
            RegisterReceiptAndPaymentListService.GetAllRegisterReceiptList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        RegisterReceipts =new ObservableCollection<RegisterReceiptAndPayment>(res);
                    }
                    else controller.HandleException(exp);
                });
            RegisterReceiptAndPaymentListService.GetAllRegisterPaymentList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        RegisterPayments = new ObservableCollection<RegisterReceiptAndPayment>(res);
                    }
                    else controller.HandleException(exp);
                });
        }
        #endregion
    }
}
