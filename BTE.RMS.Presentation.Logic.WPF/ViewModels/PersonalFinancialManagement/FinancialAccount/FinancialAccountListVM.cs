using System.Collections.ObjectModel;
using System.ComponentModel;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Presentation.Logic.WPF.Controller;
using BTE.RMS.Presentation.Logic.WPF.Wrappers;

namespace BTE.RMS.Presentation.Logic.WPF.ViewModels
{
    public class FinancialAccountListVm : WorkspaceViewModel
    {

        #region Fields
        private readonly IRMSController controller;
        private readonly IFinancialAccountListServiceWrapper financialAccountListService;

        #endregion

        #region Properties & BackFields

        private ObservableCollection<SummeryFinancialAccount> financialAccounts;

        public ObservableCollection<SummeryFinancialAccount> FinancialAccounts
        {
            get { return financialAccounts; }
            set { this.SetField(p => p.FinancialAccounts, ref financialAccounts, value); }
        }

        private SummeryFinancialAccount selectedFinancialAccount;

        public SummeryFinancialAccount SelectedFinancialAccount
        {
            get { return selectedFinancialAccount; }
            set
            {
                this.SetField(p => p.SelectedFinancialAccount, ref selectedFinancialAccount, value);
            }
        }

        #endregion

        #region Constructors

        public FinancialAccountListVm()
        {
            init();
        }
        public FinancialAccountListVm(IRMSController controller, IFinancialAccountListServiceWrapper financialAccountListService)
        {
            this.controller = controller;
            this.financialAccountListService = financialAccountListService;
            init();
        }


        #endregion

        #region Private Methods

        private void init()
        {
            DisplayName = "حساب های مالی";
            FinancialAccounts = new ObservableCollection<SummeryFinancialAccount>();
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
            financialAccountListService.GetAllfinancialAccountList(
                (res,exp) => 
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        FinancialAccounts = new ObservableCollection<SummeryFinancialAccount>(res);
                    }
                    else controller.HandleException(exp);
                });
        }
        #endregion
    }
}
