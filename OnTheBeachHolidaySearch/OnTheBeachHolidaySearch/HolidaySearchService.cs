using HolidaySearch.Models;
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

            var flights = JsonSerializer.Deserialize<List<Flight>>(flightFileContent);

            return flights;
        }
    }
}