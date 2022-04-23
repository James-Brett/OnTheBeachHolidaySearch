namespace OnTheBeachHolidaySearch.Models
{
    public class Hotel
    {
        public Hotel(
            int id,
            string name,
            DateTime arrivalDate,
            decimal pricePerNight,
            IEnumerable<string> localAirports, 
            int nights
            )
        {
            Id = id;
            Name = name;
            ArrivalDate = arrivalDate;
            PricePerNight = pricePerNight;
            LocalAirports = localAirports.ToList();
            Nights = nights;
        }

        public int Id { get; }
        public string Name { get; }
        public DateTime ArrivalDate { get; }
        public decimal PricePerNight { get; }
        public List<string> LocalAirports { get; }
        public int Nights { get; }
    }
}
