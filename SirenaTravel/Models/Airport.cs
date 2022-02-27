namespace SirenaTravel.Models
{
    public class Location
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class Airport
    {
        public string country { get; set; }
        public string city_iata { get; set; }
        public string iata { get; set; }
        public string city { get; set; }
        public string timezone_region_name { get; set; }
        public string country_iata { get; set; }
        public int rating { get; set; }
        public string name { get; set; }
        public Location location { get; set; }
        public string type { get; set; }
        public int hubs { get; set; }
    }
}
