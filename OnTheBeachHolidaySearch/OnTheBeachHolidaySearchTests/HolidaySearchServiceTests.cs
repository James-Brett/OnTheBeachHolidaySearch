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
    }
}