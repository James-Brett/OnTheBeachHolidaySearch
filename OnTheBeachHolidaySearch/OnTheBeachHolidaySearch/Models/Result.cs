namespace OnTheBeachHolidaySearch.Models
{
    public class Result
    {
        public Result(
            decimal totalPrice,
            Flight flight,
            Hotel hotel
            )
        {
            TotalPrice = totalPrice;
            Flight = flight;
            Hotel = hotel;
        }

        public decimal TotalPrice { get; }
        public Flight Flight { get; }
        public Hotel Hotel { get; }
    }
}
