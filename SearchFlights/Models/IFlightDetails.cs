using System;

namespace SearchFlights
{
    public interface IFlightDetails
    {

        string Origin { get; set; }

        string Destination { get; set; }

        DateTime DepartureTime { get; set; }

        DateTime DestinationTime { get; set; }

        double Price { get; set; }

    }
}
