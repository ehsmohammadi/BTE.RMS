namespace BTE.RMS.Model.Meetings
{
    public class Location
    {
        public string Address { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        protected Location()
        {
            
        }

        public Location(string address, string latitude, string longitude)
        {
            Address = address;
            Latitude = latitude;
            Longitude = longitude;
        }

    }
}
