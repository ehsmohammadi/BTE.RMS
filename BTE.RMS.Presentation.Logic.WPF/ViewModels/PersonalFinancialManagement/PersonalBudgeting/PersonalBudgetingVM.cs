﻿using System.Collections.ObjectModel;
using BTE.Presentation;
using BTE.RMS.Interface.Contract.PersonalFinancialManagement.PersonalBudgeting;
using BTE.RMS.Presentation.Logic.WPF.Controller;
using BTE.RMS.Presentation.Logic.WPF.Wrappers.PersonalFinancialManagement.PersonalBudgeting;

namespace BTE.RMS.Presentation.Logic.WPF.ViewModels
{
    public class PersonalBudgetingVM : WorkspaceViewModel
    {
        #region Fields
        private readonly IRMSController controller;
        private readonly IPersonalBudgetingServiceWrapper personalBudgetingService;

        #endregion

        #region Properties & BackFields

        private ObservableCollection<SummeryCost> costTopics;

        public ObservableCollection<SummeryCost> CostTopics
        {
            get { return costTopics; }
            set { this.SetField(p => p.CostTopics, ref costTopics, value); }
        }

        private SummeryCost selectedCostTopic;

        public SummeryCost SelectedCostTopic
        {
            get { return selectedCostTopic; }
            set
            {
                this.SetField(p => p.SelectedCostTopic, ref selectedCostTopic, value);
            }
        }

        private ObservableCollection<SummeryIncome> incomeTopics;

        public ObservableCollection<SummeryIncome> IncomeTopics
        {
            get { return incomeTopics; }
            set { this.SetField(p=>p.IncomeTopics,ref incomeTopics,value);}
        }

        private SummeryIncome selectedIncomeTopic;

        public SummeryIncome SelectedIncomeTopic
        {
            get { return selectedIncomeTopic; }
            set
            {
                this.SetField(p=>p.SelectedIncomeTopic,ref selectedIncomeTopic,value);
            }
        }
        #endregion

        #region Constructors

        public PersonalBudgetingVM()
        {
            init();
        }

        public PersonalBudgetingVM(IRMSController controller,IPersonalBudgetingServiceWrapper personalBudgetingService)
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
            CostTopics=new ObservableCollection<SummeryCost>();
            IncomeTopics=new ObservableCollection<SummeryIncome>();
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
            personalBudgetingService.GetAllCostTopicList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        CostTopics = new ObservableCollection<SummeryCost>(res);
                    }
                    else controller.HandleException(exp);
                });
            personalBudgetingService.GetAllIncomeTopicList(
                (res, exp) =>
                {
                    HideBusyIndicator();
                    if (exp == null)
                    {
                        IncomeTopics=new ObservableCollection<SummeryIncome>(res);
                    }
                    else controller.HandleException(exp);
                });
        }
        #endregion
    }
}
