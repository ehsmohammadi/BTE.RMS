using System;
using System.Collections.Generic;
using BTE.Presentation;
using BTE.RMS.Interface.Contract.PersonalFinancialManagement.PersonalBudgeting;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers.PersonalFinancialManagement.PersonalBudgeting
{
    public interface IPersonalBudgetingServiceWrapper:IServiceWrapper
    {
        void GetAllIncomeTopicList(Action<List<SummeryIncomeTopic>, Exception> action);
        void GetAllCostTopicList(Action<List<SummeryCostTopic>, Exception> action);
    }
}
