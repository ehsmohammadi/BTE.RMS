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
        private ObservableCollection<RegisterReceiptAndPayment> registerDownloads;

        public ObservableCollection<RegisterReceiptAndPayment> RegisterDownloads
        {
            get { return registerDownloads; }
            set { this.SetField(p => p.RegisterDownloads, ref registerDownloads, value); }
        }

        private RegisterReceiptAndPayment selectedRegisterDownload;

        public RegisterReceiptAndPayment SelectedRegisterDownload
        {
            get { return selectedRegisterDownload; }
            set
            {
                this.SetField(p => p.SelectedRegisterDownload, ref  selectedRegisterDownload, value);
            }
        }
        private ObservableCollection<RegisterReceiptAndPayment> registerPays;

        public ObservableCollection<RegisterReceiptAndPayment> RegisterPays
        {
            get { return registerPays; }
            set { this.SetField(p => p.RegisterPays, ref registerPays, value); }
        }
        private RegisterReceiptAndPayment selectedRegisterPay;

        public RegisterReceiptAndPayment SelectedRegisterPay
        {
            get { return selectedRegisterPay; }
            set { this.SetField(p => p.SelectedRegisterPay, ref selectedRegisterPay, value); }
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
            RegisterPays=new ObservableCollection<RegisterReceiptAndPayment>();
            RegisterDownloads=new ObservableCollection<RegisterReceiptAndPayment>();
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
            RegisterReceiptAndPaymentListService.GetAllRegisterDownloadList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        registerDownloads =new ObservableCollection<RegisterReceiptAndPayment>(res);
                    }
                    else controller.HandleException(exp);
                });
            RegisterReceiptAndPaymentListService.GetAllRegisterPayList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        registerPays = new ObservableCollection<RegisterReceiptAndPayment>(res);
                    }
                    else controller.HandleException(exp);
                });
        }
        #endregion
    }
}
