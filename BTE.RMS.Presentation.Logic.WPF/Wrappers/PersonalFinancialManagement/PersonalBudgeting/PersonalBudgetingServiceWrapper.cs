using System;
using System.Collections.Generic;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public class FakePersonalBudgetingServiceWrapper : IPersonalBudgetingServiceWrapper
    {
        private List<SummeryIncomeTopic> incomeTopicList = new List<SummeryIncomeTopic>
        {
            new SummeryIncomeTopic
            {
                MonthlyIncome = 200000,
                YearlyIncome = 500000000000,
                Title = "درآمد",
                 Id = 2
            }
        };
        private List<SummeryCostTopic> costTopicList = new List<SummeryCostTopic>
        {
            new SummeryCostTopic
            {
                Title = "هزینه",
                MonthlyCost = 50000,
                YearlyCost = 900000000,
                Id = 1
            }
        };
        public void GetAllIncomeTopicList(Action<List<SummeryIncomeTopic>, Exception> action)
        {
            action(incomeTopicList, null);
        }

        public void GetAllCostTopicList(Action<List<SummeryCostTopic>, Exception> action)
        {
            action(costTopicList, null);
        }
    }
}
