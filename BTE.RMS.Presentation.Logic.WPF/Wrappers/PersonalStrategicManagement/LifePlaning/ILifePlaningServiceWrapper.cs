using System;
using System.Collections.Generic;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers.PersonalStrategicManagement.LifePlaning
{
    public interface ILifePlaningServiceWrapper:IServiceWrapper
    {
        void GetAllHumanTimes(Action<List<HumanTimeInLife>, Exception> action);
        void GetAllMy90YearLifePlanings(Action<List<My90YearLifePlaning>, Exception> action);
    }
}
