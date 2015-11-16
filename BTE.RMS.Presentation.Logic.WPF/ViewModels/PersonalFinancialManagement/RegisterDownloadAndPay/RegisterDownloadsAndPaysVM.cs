using System.Collections.ObjectModel;
using System.Data.Odbc;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Presentation.Logic.WPF.Controller;
using BTE.RMS.Presentation.Logic.WPF.Wrappers;

namespace BTE.RMS.Presentation.Logic.WPF.ViewModels
{
    public class RegisterDownloadsAndPaysVM : WorkspaceViewModel
    {

        #region Fields
        private readonly IRMSController controller;
        private readonly IRegisterDownloadAndPayListServiceWrapper registerDownloadAndPayListService;

        #endregion

        #region Properties & BackFields

        /// <summary>
        /// Register Download and Register Pay Lists
        /// </summary>
        private ObservableCollection<RegisterDownloadAndPay> registerDownloads;

        public ObservableCollection<RegisterDownloadAndPay> RegisterDownloads
        {
            get { return registerDownloads; }
            set { this.SetField(p => p.RegisterDownloads, ref registerDownloads, value); }
        }

        private RegisterDownloadAndPay selectedRegisterDownload;

        public RegisterDownloadAndPay SelectedRegisterDownload
        {
            get { return selectedRegisterDownload; }
            set
            {
                this.SetField(p => p.SelectedRegisterDownload, ref  selectedRegisterDownload, value);
            }
        }
        private ObservableCollection<RegisterDownloadAndPay> registerPays;

        public ObservableCollection<RegisterDownloadAndPay> RegisterPays
        {
            get { return registerPays; }
            set { this.SetField(p => p.RegisterPays, ref registerPays, value); }
        }
        private RegisterDownloadAndPay selectedRegisterPay;

        public RegisterDownloadAndPay SelectedRegisterPay
        {
            get { return selectedRegisterPay; }
            set { this.SetField(p => p.SelectedRegisterPay, ref selectedRegisterPay, value); }
        }
        #endregion

        #region Constructors

        public RegisterDownloadsAndPaysVM()
        {
            init();
        }
        public RegisterDownloadsAndPaysVM(IRMSController controller, IRegisterDownloadAndPayListServiceWrapper registerDownloadAndPayListService)
        {
            this.controller = controller;
            this.registerDownloadAndPayListService = registerDownloadAndPayListService;
            init();
        }

        #endregion

        #region Private Methods

        private void init()
        {
            DisplayName = "ثبت دانلود ها و دریافت ها";
            RegisterPays=new ObservableCollection<RegisterDownloadAndPay>();
            RegisterDownloads=new ObservableCollection<RegisterDownloadAndPay>();
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
            registerDownloadAndPayListService.GetAllRegisterDownloadList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        registerDownloads =new ObservableCollection<RegisterDownloadAndPay>(res);
                    }
                    else controller.HandleException(exp);
                });
            registerDownloadAndPayListService.GetAllRegisterPayList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        registerPays = new ObservableCollection<RegisterDownloadAndPay>(res);
                    }
                    else controller.HandleException(exp);
                });
        }
        #endregion
    }
}
