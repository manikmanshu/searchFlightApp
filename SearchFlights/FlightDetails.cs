using System;

namespace SearchFlights
{
    public class FlightDetails
    {
        public string Origin { get; set; }

        public string Destination { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime DestinationTime { get; set; }

        public double Price { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3} {4}", Origin, DepartureTime, Destination, DestinationTime, Price);
        }

    }
}
