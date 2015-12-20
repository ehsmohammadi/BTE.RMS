using System;
using System.Collections.Generic;
using System.Linq;
using BTE.RMS.Interface.Contract;

namespace BTE.RMS.Presentation.Logic.WPF.Wrappers
{
    public class CityDistanceServiceWrapper : ICityDistanceServiceWrapper
    {
        private List<City> cityList=new List<City>
        {
            new City
            {
                CityType = CityType.Source,
                Name = "تهران",
                Id = 1000
            },
            new City
            {
                CityType = CityType.Destination,
                Name = "مشهد",
                Id = 1001
            },
            new City
            {
                CityType = CityType.Destination,
                Name = "اراک",
            }
        }; 

        public void GetAllSourceCity(Action<List<City>, Exception> action)
        {
            action(cityList.Where(e => e.CityType == CityType.Source).ToList(), null);
        }

        public void GetAllDestinationCity(Action<List<City>, Exception> action)
        {
            action(cityList.Where(e => e.CityType == CityType.Destination).ToList(), null);
        }
    }
}
