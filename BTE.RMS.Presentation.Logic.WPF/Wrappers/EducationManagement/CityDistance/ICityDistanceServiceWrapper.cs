using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE.Presentation;
using BTE.RMS.Interface.Contract.EducationManagement;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers.EducationManagement.CityDistance
{
    public interface ICityDistanceServiceWrapper:IServiceWrapper
    {
        void GetAllCityDistanceServiceList(Action<List<City>, Exception> action);
    }
}
