namespace OnTheBeachHolidaySearch.Models.Json
{
    public class JsonFlight
    {
        public int id { get; set; }
        public string airline { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public decimal price { get; set; }
        public string departure_date { get; set; }
    }
}
