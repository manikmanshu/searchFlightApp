using CommandLine;

namespace SearchFlights
{
    public class CommandLineOptions
    {
        [Option('o', "origin", Required = true, HelpText = "Origin")]
        public string Origin { get; set; }

        [Option('d', "destination", Required = true, HelpText = "destination")]
        public string Destination { get; set; }
    }
}
