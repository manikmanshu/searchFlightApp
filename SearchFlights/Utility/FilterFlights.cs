using System.Collections.Generic;
using System.Linq;

namespace SearchFlights
{
    /// <summary>
    /// Filter Flights
    /// static class
    /// </summary>
    public static class FilterFlights
    {
        /// <summary>
        /// Get Flights filtered as per options passed
        /// </summary>
        /// <param name="flights">list of IFlightDetails</param>
        /// <param name="cmdOptions">CommandLineOptions</param>
        /// <returns>List<IFlightDetails></returns>
        public static List<IFlightDetails> GetFlights(List<IFlightDetails> flights, CommandLineOptions cmdOptions)
        {
            List<IFlightDetails> filtered = flights
                .Where(flight => flight.Origin.Equals(cmdOptions.Origin) && flight.Destination.Equals(cmdOptions.Destination))
                .OrderBy(flight => flight.Price).ThenBy(flight => flight.DepartureTime)                
                .ToList();

            return filtered;
        }

    }
}
