using System;
using System.Collections.Generic;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public class CityDistanceServiceWrapper : ICityDistanceServiceWrapper
    {
        private List<CrudCity> citySettingList = new List<CrudCity>
        {
            new CrudCity
            {
                Name = "تبریز"
            },
            new CrudCity
            {
                Name = "تهران"
            }
        }; 
        public void GetAllCityDistanceServiceList(Action<List<CrudCity>, Exception> action)
        {
            action(citySettingList, null);
        }
    }
}
