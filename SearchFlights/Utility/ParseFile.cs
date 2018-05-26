using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace SearchFlights.Utility
{
    public class ParseFile
    {
        public static List<FlightDetails> ParseFlightDetailsFile(string path)
        {
            string line;
            char split = ',';
            List<FlightDetails> flights = new List<FlightDetails>();
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);

            using (StreamReader streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                line = streamReader.ReadLine();
                if (line.Contains("|"))
                {
                    split = '|';
                }
                while ((line = streamReader.ReadLine()) != null)
                {
                    FlightDetails flightDetail = parseLineToFlightDetails(line, split);
                    flights.Add(flightDetail);
                }
            }
            return flights;
        }

        private static FlightDetails parseLineToFlightDetails(string line, char split)
        {
            FlightDetails flightDetail = new FlightDetails();
            string[] props = line.Split(split);
            DateTimeStyles styles = DateTimeStyles.AdjustToUniversal;
            flightDetail.Origin = props[0];
            flightDetail.Destination = props[2];
            flightDetail.Price = Double.Parse(props[4], NumberStyles.Currency);

            DateTime date;

            if (DateTime.TryParse(props[1], CultureInfo.InvariantCulture, styles, out date))
            {
                flightDetail.DepartureTime = date;
            }

            if (DateTime.TryParse(props[3], CultureInfo.InvariantCulture, styles, out date))
            {
                flightDetail.DestinationTime = date;
            }

            return flightDetail;
        }
    }
}
