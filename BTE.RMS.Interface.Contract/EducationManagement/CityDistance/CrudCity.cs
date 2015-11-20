using BTE.Presentation;

namespace BTE.RMS.Interface.Contract
{
    public class CrudCity:City
    {
        private double longitude;

        public double Longitude
        {
            get { return longitude; }
            set { this.SetField(p=>p.Longitude,ref longitude,value);}
        }

        private double latitude;

        public double Latitude
        {
            get { return latitude; }
            set { this.SetField(p=>p.Latitude,ref latitude,value);}
        }
    }
}
