using System.Collections.ObjectModel;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;
using BTE.RMS.Presentation.Logic.WPF.Controller;
using BTE.RMS.Presentation.Logic.WPF.Wrappers;

namespace BTE.RMS.Presentation.Logic.WPF.ViewModels
{
    public class PersonalBudgetingListVM : WorkspaceViewModel
    {
        #region Fields
        private readonly IRMSController controller;
        private readonly IPersonalBudgetingServiceWrapper personalBudgetingService;

        #endregion

        #region Properties & BackFields

        private ObservableCollection<SummeryCostTopic> costTopics;

        public ObservableCollection<SummeryCostTopic> CostTopics
        {
            get { return costTopics; }
            set { this.SetField(p => p.CostTopics, ref costTopics, value); }
        }

        private SummeryCostTopic selectedCostTopic;

        public SummeryCostTopic SelectedCostTopic
        {
            get { return selectedCostTopic; }
            set
            {
                this.SetField(p => p.SelectedCostTopic, ref selectedCostTopic, value);
            }
        }

        private ObservableCollection<SummeryIncomeTopic> incomeTopics;

        public ObservableCollection<SummeryIncomeTopic> IncomeTopics
        {
            get { return incomeTopics; }
            set { this.SetField(p=>p.IncomeTopics,ref incomeTopics,value);}
        }

        private SummeryIncomeTopic selectedIncomeTopic;

        public SummeryIncomeTopic SelectedIncomeTopic
        {
            get { return selectedIncomeTopic; }
            set
            {
                this.SetField(p=>p.SelectedIncomeTopic,ref selectedIncomeTopic,value);
            }
        }

        private CommandViewModel createCmd;
        public CommandViewModel CreateCmd
        {
            get
            {
                if (createCmd == null)
                {
                    createCmd = new CommandViewModel("سرفصل جدید", new DelegateCommand(create));
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

        public PersonalBudgetingListVM()
        {
            init();
        }

        public PersonalBudgetingListVM(IRMSController controller, IPersonalBudgetingServiceWrapper personalBudgetingService)
        {
            this.controller = controller;
            this.personalBudgetingService = personalBudgetingService;
            init();
        }

        #endregion

        #region Private Methods

        public void init()
        {
            DisplayName = "سررسید تهدات و چک ها";
            CostTopics=new ObservableCollection<SummeryCostTopic>();
            IncomeTopics=new ObservableCollection<SummeryIncomeTopic>();
        }
        protected override void OnRequestClose()
        {
            base.OnRequestClose();
            controller.Close(this);
        }

        private void create()
        {
            controller.ShowPersonalBudgetingView();
        }

        public void modify()
        {
            controller.ShowPersonalBudgetingView();
        }
        public void delete()
        {
            controller.ShowPersonalBudgetingView();
        }
        #endregion

        #region Public Methods

        public void Load()
        {
            personalBudgetingService.GetAllCostTopicList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        CostTopics = new ObservableCollection<SummeryCostTopic>(res);
                    }
                    else controller.HandleException(exp);
                });
            personalBudgetingService.GetAllIncomeTopicList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        IncomeTopics=new ObservableCollection<SummeryIncomeTopic>(res);
                    }
                    else controller.HandleException(exp);
                });
        }
        #endregion
    }
}
