using System.Collections.ObjectModel;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Presentation.Logic.Controller;
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
        private CommandViewModel createCmd;
        public CommandViewModel CreateCmd
        {
            get
            {
                if (createCmd == null)
                {
                    createCmd = new CommandViewModel("حساب جدید", new DelegateCommand(create));
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
        private void create()
        {
            controller.ShowFinancialAccountsView();
        }

        public void modify()
        {
            controller.ShowFinancialAccountsView();
        }
        public void delete()
        {
            controller.ShowFinancialAccountsView();
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
