using System;
using System.Collections.Generic;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers.EducationManagement.CityDistance
{
    public class CityDistanceServiceWrapper : ICityDistanceServiceWrapper
    {
        private List<CrudCitySettings> citySettingList = new List<CrudCitySettings>
        {
            new CrudCitySettings
            {
                Name = "تبریز"
            },
            new CrudCitySettings
            {
                Name = "تهران"
            }
        }; 
        public void GetAllCityDistanceServiceList(Action<List<CrudCitySettings>, Exception> action)
        {
            action(citySettingList, null);
        }
    }
}
