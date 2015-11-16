using System;
using System.Collections.Generic;
using BTE.RMS.Interface.Contract.PersonalFinancialManagement.PersonalBudgeting;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers.PersonalFinancialManagement.PersonalBudgeting
{
    public class FakePersonalBudgetingServiceWrapper:IPersonalBudgetingServiceWrapper
    {
        private List<SummeryCostTopic> costTopicList = new List<SummeryCostTopic>
        {
            new SummeryCostTopic
            {
                Title = "ماشین/سوخت",
                MonthlyCost = 300000,
                YearlyCost = 54000000000
            }
        };
        public void GetAllCostTopicList(Action<List<SummeryCostTopic>, Exception> action)
        {
            action(costTopicList, null);
        }
        private List<SummeryIncomeTopic> incomeTopicList = new List<SummeryIncomeTopic>
        {
            new SummeryIncomeTopic
            {
                Title = "درآمد حقوق",
                MonthlyIncome = 500000,
                YearlyIncome = 700000000
            }
        }; 
        public void GetAllIncomeTopicList(System.Action<List<SummeryIncomeTopic>, System.Exception> action)
        {
            action(incomeTopicList, null);
        }
    }
}
