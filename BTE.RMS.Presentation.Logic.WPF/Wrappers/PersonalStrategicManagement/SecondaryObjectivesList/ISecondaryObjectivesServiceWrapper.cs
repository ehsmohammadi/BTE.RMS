using System;
using System.Collections.Generic;
using BTE.Presentation;
using BTE.RMS.Interface.Contract.PersonalStrategicManagement.SecondaryObjectives;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers.PersonalStrategicManagement.SecondaryObjectivesList
{
    public interface ISecondaryObjectivesServiceWrapper:IServiceWrapper
    {
        void GetAllSecondaryObjectives(Action<List<SummerySecondaryObjectives>, Exception> action);
    }
}
