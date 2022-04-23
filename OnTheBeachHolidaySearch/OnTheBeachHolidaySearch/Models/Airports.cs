using System;

namespace OnTheBeachHolidaySearch.Models
{
    public static class Airports
    {
        public static string[] AnyLondonAirport = new string[]
        {
            "LCY", "LHR", "LGW", "LTN", "STN", "SEN"
        };

        public static string[] AnyAirport = Array.Empty<string>(); //using the empty array for 'any airport'
    }
}
