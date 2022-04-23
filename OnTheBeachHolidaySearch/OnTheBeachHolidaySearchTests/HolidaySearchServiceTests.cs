using OnTheBeachHolidaySearch;
using OnTheBeachHolidaySearch.Models;
using System.Collections.Generic;
using System.Linq;
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

        [Fact]
        public void ImportHotels_ReturnsPopulatedList()
        {
            var hotels = HolidaySearchService.ImportHotels();
            Assert.NotEmpty(hotels);
        }

        [Fact]
        public void ImportHotels_HasCorrectValueForItem()
        {
            var hotels = HolidaySearchService.ImportHotels();
            var hotel = hotels[0];
            Assert.Equal(1, hotel.Id);
            Assert.Equal("Iberostar Grand Portals Nous", hotel.Name);
            Assert.Equal("2022-11-05", $"{hotel.ArrivalDate:yyyy-MM-dd}");
            Assert.Equal(100, hotel.PricePerNight);
            Assert.Single(hotel.LocalAirports);
            Assert.Equal("TFS", hotel.LocalAirports[0]);
            Assert.Equal(7, hotel.Nights);
        }

        [Fact]
        public void ImportHotels_AssignsAllValuesProperly()
        {
            var hotels = HolidaySearchService.ImportHotels();
            foreach (var hotel in hotels)
            {
                Assert.NotEqual(0, hotel.Id);
                Assert.NotEqual(0, hotel.Nights);
                Assert.False(string.IsNullOrWhiteSpace(hotel.Name));
                Assert.Single(hotel.LocalAirports);
                Assert.NotEqual(0, hotel.PricePerNight);
                Assert.NotEqual(default, hotel.ArrivalDate);
            }
        }

        [Fact]
        public void SearchService_ReturnsResult()
        {
            var search = new HolidaySearch("MAN", "AGP", "2023/07/01", 7);
            var results = search.Results();
            Assert.IsType<List<Result>>(results);
        }

        [Fact]
        public void SearchService_ReturnsPopulatedResult()
        {
            var search = new HolidaySearch("MAN", "AGP", "2023/07/01", 7);
            var results = search.Results();
            Assert.NotEmpty(results);
        }

        [Fact]
        public void SearchService_ReturnsExactResult_1()
        {
            var search = new HolidaySearch("MAN", "AGP", "2023/07/01", 7);
            var results = search.Results();
            Assert.NotEmpty(results);

            var firstResult = results.First();
            Assert.Equal(826, firstResult.TotalPrice);
            Assert.Equal(2, firstResult.Flight.Id);
            Assert.Equal(9, firstResult.Hotel.Id);
        }

        [Fact]
        public void SearchService_ReturnsExactResult_2()
        {
            var search = new HolidaySearch(Airports.AnyLondonAirport, "PMI", "2023/06/15", 10);
            var results = search.Results();
            Assert.NotEmpty(results);

            var firstResult = results.First();
            Assert.Equal(6, firstResult.Flight.Id);
            Assert.Equal(5, firstResult.Hotel.Id);
        }

        [Fact]
        public void SearchService_ReturnsExactResult_3()
        {
            var search = new HolidaySearch(Airports.AnyAirport, "LPA", "2022/11/10", 14);
            var results = search.Results();
            Assert.NotEmpty(results);

            var firstResult = results.First();
            Assert.Equal(7, firstResult.Flight.Id);
            Assert.Equal(6, firstResult.Hotel.Id);
        }
    }
}