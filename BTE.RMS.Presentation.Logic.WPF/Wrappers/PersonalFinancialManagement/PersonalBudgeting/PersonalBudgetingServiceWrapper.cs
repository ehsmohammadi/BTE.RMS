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
                Id = 1000,
                MonthlyIncome = 2000000,
                Title = "دریافت مبلغ از ایران خودرو",
                YearlyIncome = 40000000000000,
            }
        };
        private List<SummeryCostTopic> costTopicList = new List<SummeryCostTopic>
        {
            new SummeryCostTopic
            {
                Id = 1001,
                MonthlyCost = 300000,
                Title = "پرداخت هزینه برای ساخت منزل",
                YearlyCost = 500000000
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
