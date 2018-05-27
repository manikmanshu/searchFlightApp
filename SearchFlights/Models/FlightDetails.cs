using System;

namespace SearchFlights
{
    public class FlightDetails : IFlightDetails
    {
        /// <summary>
        /// Get or set flight origin
        /// </summary>
        public string Origin { get; set; }

        /// <summary>
        /// Get or set Flight destination
        /// </summary>
        public string Destination { get; set; }

        /// <summary>
        /// Get or set Flight deparature time
        /// </summary>
        public DateTime DepartureTime { get; set; }

        /// <summary>
        /// Get or set Flight Arrival/Destination time
        /// </summary>
        public DateTime DestinationTime { get; set; }

        /// <summary>
        /// Get or set Flight cost
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Override to string method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3} {4}", Origin, DepartureTime, Destination, DestinationTime, Price);
        }

        public override bool Equals(Object other)
        {
            if (other.GetType() != typeof(FlightDetails))
            {
                return false;
            }
            FlightDetails fd = (other as FlightDetails);
            return Origin.Equals(fd.Origin) &&
                Destination.Equals(fd.Destination) &&
                Price == fd.Price &&
                DepartureTime.Equals(fd.DepartureTime) &&
                DestinationTime.Equals(fd.DestinationTime);
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

    }
}
