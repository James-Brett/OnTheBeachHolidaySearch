namespace OnTheBeachHolidaySearch.Models
{
    public class Flight
    {
        public Flight(
            int id,
            string airline,
            string from,
            string to,
            decimal price,
            DateTime depatureDate
            )
        {
            Id = id;
            Airline = airline;
            From = from;
            To = to;
            Price = price;
            DepartureDate = depatureDate;
        }

        public int Id { get; }
        public string Airline { get; }
        public string From { get; }
        public string To { get; }
        public decimal Price { get; }
        public DateTime DepartureDate { get; }
    }
}
