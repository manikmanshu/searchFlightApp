using SearchFlights.Utility;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SearchFlights
{
    /// <summary>
    /// Initialize application data
    /// </summary>
    public class InitializeData
    {
        #region Private fields

        private IList<IFlightDetails> flights;
        private HashSet<IFlightDetails> flightSet = new HashSet<IFlightDetails>(new FlightDetailEqualityComparer());

        private const string File1 = @"Provider1.txt";
        private const string File2 = @"Provider2.txt";
        private const string File3 = @"Provider3.txt";

        #endregion

        #region Constructor

        /// <summary>
        /// InitializeData
        /// </summary>
        public InitializeData()
            : this(new List<IFlightDetails>())
        {

        }

        /// <summary>
        /// InitializeData
        /// </summary>
        /// <param name="flights">List<IFlightDetails> flights</param>
        public InitializeData(IList<IFlightDetails> flights)
        {
            this.flights = flights;
        }

        #endregion

        /// <summary>
        /// Get flights
        /// </summary>
        /// <returns>List<IFlightDetails></returns>
        public IList<IFlightDetails> Flights
        {
            get
            {
                return this.flights;
            }
        }

        #region Public Methods

        /// <summary>
        /// Parse files from Flights details data
        /// </summary>
        public void ParseFiles()
        {
            AddFlightInASet(ParseAFile(File1));
            AddFlightInASet(ParseAFile(File2));
            AddFlightInASet(ParseAFile(File3));

            // Store list
            this.flights = flightSet.ToList();
        }

        /// <summary>
        /// Parse a single file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static IList<IFlightDetails> ParseAFile(string fileName)
        {
            return ParseFile.ParseFlightDetailsFile(Path.GetFullPath(fileName));
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Add fight in a set helper method
        /// </summary>
        /// <param name="flights"></param>
        private void AddFlightInASet(IList<IFlightDetails> flights)
        {
            foreach (IFlightDetails fd in flights)
            {
                flightSet.Add(fd);
            }
        }

        #endregion
    }
}
