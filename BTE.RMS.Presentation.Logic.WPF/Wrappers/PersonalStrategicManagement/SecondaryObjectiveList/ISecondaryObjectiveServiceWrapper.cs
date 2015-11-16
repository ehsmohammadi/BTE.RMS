using System;
using System.Collections.Generic;
using BTE.Presentation;
using BTE.RMS.Interface.Contract.PersonalStrategicManagement.SecondaryObjectives;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers.PersonalStrategicManagement.SecondaryObjectivesList
{
    public interface ISecondaryObjectiveServiceWrapper:IServiceWrapper
    {
        void GetAllSecondaryObjectives(Action<List<SummerySecondaryObjective>, Exception> action);
    }
}
