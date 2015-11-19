using System;
using System.Collections.Generic;
using BTE.Presentation;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public interface ICityDistanceServiceWrapper:IServiceWrapper
    {
        void GetAllCityDistanceServiceList(Action<List<CrudCitySettings>, Exception> action);
    }
}
