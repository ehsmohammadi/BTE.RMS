using System.Collections.ObjectModel;
using System.ComponentModel;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Presentation.Logic.WPF.Controller;
using BTE.RMS.Presentation.Logic.WPF.Wrappers;

namespace BTE.RMS.Presentation.Logic.WPF.ViewModels
{
    public class FinancialAccountsListVm : WorkspaceViewModel
    {

        #region Fields
        private readonly IRMSController controller;
        private readonly IFinancialAccountsListServiceWrapper financialAccountListService;

        #endregion

        #region Properties & BackFields

        private ObservableCollection<SummeryFinancialAccounts> financialAccountses;

        public ObservableCollection<SummeryFinancialAccounts> FinancialAccountses
        {
            get { return financialAccountses; }
            set { this.SetField(p => p.FinancialAccountses, ref financialAccountses, value); }
        }

        private SummeryFinancialAccounts selectedFinancialAccounts;

        public SummeryFinancialAccounts SelectedFinancialAccounts
        {
            get { return selectedFinancialAccounts; }
            set
            {
                this.SetField(p => p.SelectedFinancialAccounts, ref selectedFinancialAccounts, value);
            }
        }

        #endregion

        #region Constructors

        public FinancialAccountsListVm()
        {
            init();
        }
        public FinancialAccountsListVm(IRMSController controller, IFinancialAccountsListServiceWrapper financialAccountListService)
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
            FinancialAccountses = new ObservableCollection<SummeryFinancialAccounts>();
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
                        FinancialAccountses = new ObservableCollection<SummeryFinancialAccounts>(res);
                    }
                    else controller.HandleException(exp);
                });
        }
        #endregion
    }
}
