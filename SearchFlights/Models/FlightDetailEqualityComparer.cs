using System.Collections.Generic;

namespace SearchFlights
{
    /// <summary>
    /// FlightDetailEqualityComparer check for duplicates
    /// </summary>
    public class FlightDetailEqualityComparer : IEqualityComparer<IFlightDetails>
    {
        /// <summary>
        /// Implement Equals Method
        /// </summary>
        /// <param name="x">IFlightDetails</param>
        /// <param name="y">IFlightDetails</param>
        /// <returns>bool</returns>
        public bool Equals(IFlightDetails x, IFlightDetails y)
        {
            return x.Equals(y);
        }

        /// <summary>
        /// Implements GetHashCode Method
        /// </summary>
        /// <param name="flightDetails">IFlightDetails</param>
        /// <returns>int</returns>
        public int GetHashCode(IFlightDetails flightDetails)
        {
            return flightDetails.ToString().GetHashCode();
        }
    }
}
