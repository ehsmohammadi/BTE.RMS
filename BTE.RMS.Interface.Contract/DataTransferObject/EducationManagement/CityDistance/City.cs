﻿using System.Runtime.CompilerServices;
using BTE.Presentation;

namespace BTE.RMS.Interface.Contract
{
    public class City:ViewModelBase
    {
        private long id;
        public long Id
        {
            get { return id; }
            set { this.SetField(p => p.Id, ref id, value); }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { this.SetField(p => p.Name, ref name, value); }
        }

        private long distance;

        public long Distance
        {
            get { return distance; }
            set { this.SetField(p=>p.Distance,ref distance,value);}
        }

        private CityType cityType;

        public CityType CityType
        {
            get { return cityType; }
            set { this.SetField(p=>p.CityType,ref cityType,value);}
        }

    }
}
