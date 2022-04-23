using OnTheBeachHolidaySearch.Models.Json;
using OnTheBeachHolidaySearch.Models;
using System.Globalization;
using System.Reflection;
using System.Text.Json;

namespace OnTheBeachHolidaySearch
{
    public static class HolidaySearchService
    {
        public static List<Flight> ImportFlights()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (path is null) throw new Exception("Unable to determine the executing assembly's directory.");

            var flightFilePath = Path.Combine(path, "Files\\flights.json");

            var flightFileContent = File.ReadAllText(flightFilePath);

            var flights = JsonSerializer.Deserialize<List<JsonFlight>>(flightFileContent);

            return flights.ConvertAll(f => new Flight
            (
                f.id,
                f.airline,
                f.from,
                f.to,
                f.price,
                DateTime.ParseExact(f.departure_date, "yyyy-MM-dd", CultureInfo.InvariantCulture)
            ));
        }

        public static List<Hotel> ImportHotels()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (path is null) throw new Exception("Unable to determine the executing assembly's directory.");

            var hotelFilePath = Path.Combine(path, "Files\\hotels.json");

            var hotelFileContent = File.ReadAllText(hotelFilePath);

            var hotels = JsonSerializer.Deserialize<List<JsonHotel>>(hotelFileContent);

            return hotels.ConvertAll(h => new Hotel
            (
                h.id,
                h.name,
                DateTime.ParseExact(h.arrival_date, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                h.price_per_night,
                h.local_airports,
                h.nights
            ));
        }

        public static List<Result> Results(this HolidaySearch search)
        {
            var flights = ImportFlights();
            var hotels = ImportHotels();
            var results = new List<Result>();

            var matchingHotels = hotels
                .Where(h =>
                    search.DepartureDate == h.ArrivalDate &&
                    search.Duration == h.Nights &&
                    h.LocalAirports.Contains(search.TravelingTo)
                );

            var matchingFlights = flights
                .Where(f =>
                    (!search.DepartingFrom.Any() || search.DepartingFrom.Contains(f.From)) && //if empty array then any airport is valid
                    search.TravelingTo == f.To &&
                    search.DepartureDate == f.DepartureDate
                );

            foreach (var hotel in matchingHotels)
            {
                foreach (var flight in matchingFlights)
                {
                    results.Add(new Result
                    (
                        flight.Price + hotel.PricePerNight * hotel.Nights,
                        flight,
                        hotel
                    ));
                }
            }

            return results
                .OrderBy(f => f.TotalPrice)
                .ToList();
        }
    }
}