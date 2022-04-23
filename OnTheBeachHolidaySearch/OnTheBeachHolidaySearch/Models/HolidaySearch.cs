using System.Globalization;

namespace OnTheBeachHolidaySearch.Models
{
    public class HolidaySearch
    {
        public HolidaySearch(
            string departingFrom,
            string travellingTo,
            string departureDate,
            int duration
            )
        {
            DepartingFrom = new string[] { departingFrom };
            TravelingTo = travellingTo;
            DepartureDate = DateTime.ParseExact(departureDate, "yyyy/MM/dd", CultureInfo.InvariantCulture);
            Duration = duration;
        }

        public HolidaySearch(
            string[] departingFrom,
            string travellingTo,
            string departureDate,
            int duration
            )
        {
            DepartingFrom = departingFrom;
            TravelingTo = travellingTo;
            DepartureDate = DateTime.ParseExact(departureDate, "yyyy/MM/dd", CultureInfo.InvariantCulture);
            Duration = duration;
        }

        public string[] DepartingFrom { get; }
        public string TravelingTo { get; }
        public DateTime DepartureDate { get; }
        public int Duration { get; }
    }
}
