using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Globalization;
[assembly: CLSCompliant(true)]
namespace SearchFlights
{
    class Program
    {
        private static InitializeData initializeData;
        static void Main(string[] args)
        {
            CommandLineOptions cmdOptions = null;
            Parser parser = new Parser();
            ParserResult<CommandLineOptions> parserResult = parser.ParseArguments<CommandLineOptions>(args);
            parserResult.WithParsed<CommandLineOptions>(opts => cmdOptions = opts);
            parserResult.WithNotParsed(errs =>
            {
                HelpText helpText = HelpText.AutoBuild(parserResult, h =>
                {
                    // Configure HelpText here  or create your own and return it 
                    h.AdditionalNewLineAfterOption = false;
                    return HelpText.DefaultParsingErrorsHandler(parserResult, h);
                }, e =>
                {
                    return e;
                });
                Console.Error.Write(helpText);
            });


            if (cmdOptions == null || cmdOptions.Origin.Length == 0 || cmdOptions.Destination.Length == 0)
            {

            }
            else
            {
                Initialize();
                ExecuteQuery(cmdOptions);
            }

            Console.Read();
        }

        /// <summary>
        /// Initialize application data
        /// </summary>
        static void Initialize()
        {
            initializeData = new InitializeData();
            initializeData.ParseFiles();
        }


        /// <summary>
        /// Execute User Query
        /// </summary>
        /// <param name="cmdOptions"></param>
        static void ExecuteQuery(CommandLineOptions cmdOptions)
        {
            IList<IFlightDetails> filteredFlights = FilterFlights.GetFlights(initializeData.Flights, cmdOptions);
            if (filteredFlights.Count == 0)
            {
                Console.WriteLine("No Flights Found for {0} --> {1}", cmdOptions.Origin, cmdOptions.Destination);
            }
            foreach (IFlightDetails fd in filteredFlights)
            {
                Console.WriteLine(Constants.FlightOutput,
                                  cmdOptions.Origin,
                                  cmdOptions.Destination,
                                  fd.DepartureTime.ToString("M/dd/yyyy h:mm:ss", CultureInfo.InvariantCulture),
                                  fd.DestinationTime.ToString("M/dd/yyyy h:mm:ss", CultureInfo.InvariantCulture),
                                  fd.Price.ToString("0.00", CultureInfo.CurrentCulture));
            }
        }        
    }
}
