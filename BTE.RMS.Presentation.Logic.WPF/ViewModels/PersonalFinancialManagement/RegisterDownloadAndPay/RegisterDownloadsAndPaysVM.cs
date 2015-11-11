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
        private ObservableCollection<SummeryRegisterDownloads> registerDownloadses;

        public ObservableCollection<SummeryRegisterDownloads> RegisterDownloadses
        {
            get { return registerDownloadses; }
            set { this.SetField(p => p.RegisterDownloadses, ref registerDownloadses, value); }
        }

        private SummeryRegisterDownloads selectedRegisterDownloads;

        public SummeryRegisterDownloads SelectedRegisterDownloads
        {
            get { return selectedRegisterDownloads; }
            set
            {
                this.SetField(p => p.SelectedRegisterDownloads, ref  selectedRegisterDownloads, value);
                if (selectedRegisterDownloads == null) return;
            }
        }

        private ObservableCollection<SummeryRegisterPays> registerPayses;

        public ObservableCollection<SummeryRegisterPays> RegisterPayses
        {
            get { return registerPayses; }
            set { this.SetField(p => p.RegisterPayses, ref registerPayses, value); }
        }

        private SummeryRegisterPays selectedRegisterPays;

        public SummeryRegisterPays SelectedRegisterPays
        {
            get { return selectedRegisterPays; }
            set { this.SetField(p => p.SelectedRegisterPays, ref selectedRegisterPays, value); }
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
            registerDownloadses = new ObservableCollection<SummeryRegisterDownloads>();
            registerPayses = new ObservableCollection<SummeryRegisterPays>();
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
            registerDownloadAndPayListService.GetAllRegisterDownload(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        registerDownloadses = new ObservableCollection<SummeryRegisterDownloads>(res);
                    }
                    else controller.HandleException(exp);
                });
            registerDownloadAndPayListService.GetAllRegisterPay(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        registerPayses = new ObservableCollection<SummeryRegisterPays>(res);
                    }
                    else controller.HandleException(exp);
                });
        }
        #endregion
    }
}
