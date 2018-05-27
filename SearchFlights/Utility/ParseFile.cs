using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace SearchFlights.Utility
{
    /// <summary>
    /// Parse file utility class
    /// </summary>
    public static class ParseFile
    {
        /// <summary>
        /// Parse given file for flight details
        /// </summary>
        /// <param name="path">file path</param>
        /// <returns>List<IFlightDetails></returns>
        public static IList<IFlightDetails> ParseFlightDetailsFile(string path)
        {
            string line;
            char split = ',';
            List<IFlightDetails> flights = new List<IFlightDetails>();
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
                    IFlightDetails flightDetail = parseLineToFlightDetails(line, split);
                    flights.Add(flightDetail);
                }
            }
            return flights;
        }

        /// <summary>
        /// Parse file line to create Flight details model
        /// </summary>
        /// <param name="line">string</param>
        /// <param name="split">split character</param>
        /// <returns></returns>
        private static IFlightDetails parseLineToFlightDetails(string line, char split)
        {
            IFlightDetails flightDetail = new FlightDetails();
            string[] props = line.Split(split);
            DateTimeStyles styles = DateTimeStyles.AdjustToUniversal;
            flightDetail.Origin = props[0];
            flightDetail.Destination = props[2];
            flightDetail.Price = Double.Parse(props[4], NumberStyles.Currency, CultureInfo.CurrentCulture);

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
