using System;
using System.Collections.Generic;
using BTE.RMS.Interface.Contract.EducationManagement;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers.EducationManagement.CityDistance
{
    public class CityDistanceServiceWrapper:ICityDistanceServiceWrapper
    {
        private List<City> cityList=new List<City>
        {
            new City
            {
                Name = "تهران"
            },

            new City
            {
                Name = "تبریز",
            }
        }; 
        public void GetAllCityDistanceServiceList(Action<List<City>, Exception> action)
        {
            action(cityList, null);
        }
    }
}
