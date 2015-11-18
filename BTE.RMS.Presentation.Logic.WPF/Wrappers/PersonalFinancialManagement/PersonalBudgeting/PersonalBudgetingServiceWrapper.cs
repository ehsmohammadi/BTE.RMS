using System;
using System.Collections.Generic;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers.PersonalFinancialManagement.PersonalBudgeting
{
    public class FakePersonalBudgetingServiceWrapper:IPersonalBudgetingServiceWrapper
    {
        private List<SummeryCost> costTopicList = new List<SummeryCost>
        {
            new SummeryCost
            {
                Title = "ماشین/سوخت",
                MonthlyCost = 300000,
                YearlyCost = 54000000000
            }
        };
        public void GetAllCostTopicList(Action<List<SummeryCost>, Exception> action)
        {
            action(costTopicList, null);
        }
        private List<SummeryIncome> incomeTopicList = new List<SummeryIncome>
        {
            new SummeryIncome
            {
                Title = "درآمد حقوق",
                MonthlyIncome = 500000,
                YearlyIncome = 700000000
            }
        }; 
        public void GetAllIncomeTopicList(Action<List<SummeryIncome>, Exception> action)
        {
            action(incomeTopicList, null);
        }
    }
}
