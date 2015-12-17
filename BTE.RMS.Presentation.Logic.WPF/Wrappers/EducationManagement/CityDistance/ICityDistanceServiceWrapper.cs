using System;
using System.Collections.Generic;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public interface ICityDistanceServiceWrapper:IServiceWrapper
    {
        void GetAllSourceCity(Action<List<City>, Exception> action);
        void GetAllDestinationCity(Action<List<City>, Exception> action);
    }
}
