using OnTheBeachHolidaySearch;
using Xunit;

namespace OnTheBeachHolidaySearchTests
{
    public class HolidaySearchServiceTests
    {
        [Fact]
        public void ImportFlight_ReturnsPopulatedList()
        {
            var flights = HolidaySearchService.ImportFlights();
            Assert.NotEmpty(flights);
        }

        [Fact]
        public void ImportFlight_HasCorrectValueForItem()
        {
            var flights = HolidaySearchService.ImportFlights();
            var flight = flights[0];
            Assert.Equal(1, flight.Id);
            Assert.Equal("First Class Air", flight.Airline);
            Assert.Equal("MAN", flight.From);
            Assert.Equal("TFS", flight.To);
            Assert.Equal(470, flight.Price);
            Assert.Equal("2023-07-01", $"{flight.DepartureDate:yyyy-MM-dd}");
        }

        [Fact]
        public void ImportFlights_AssignsAllValuesProperly()
        {
            var flights = HolidaySearchService.ImportFlights();
            foreach (var flight in flights)
            {
                Assert.NotEqual(0, flight.Id);
                Assert.False(string.IsNullOrWhiteSpace(flight.Airline));
                Assert.False(string.IsNullOrWhiteSpace(flight.From));
                Assert.False(string.IsNullOrWhiteSpace(flight.To));
                Assert.NotEqual(0, flight.Price);
                Assert.NotEqual(default, flight.DepartureDate);
            }
        }
    }
}