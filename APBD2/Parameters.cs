using System;
using System.IO;

namespace APBD2
{
    public class Parameters
    {
        private const string DefaultSource = "data.csv";
        private const string DefaultDestination = "result.xml";
        private const string DefaultFormat = "xml";

        public string Source { get; private set; }
        public string Destination { get; private set; }
        public string Format { get; private set; }

        public Parameters(string[] args)
        {
            if (args.Length == 3)
            {
                Source = ParseSource(args[0]);
                Destination = ParseDestination(args[1]);
                Format = args[2];
            }
            else if (args.Length == 2)
            {
                Source = ParseSource(args[0]);
                Destination = ParseDestination(args[1]);
                Format = DefaultFormat;
            }
            else if (args.Length == 2)
            {
                Source = ParseSource(args[0]);
                Destination = DefaultDestination;
                Format = DefaultFormat;
            }
            else
            {
                Source = DefaultSource;
                Destination = DefaultDestination;
                Format = DefaultFormat;
            }
        }

        private string ParseSource(string arg)
        {
            if (!File.Exists(arg))
            {
                throw new FileNotFoundException($"Plik {arg} nie istnieje");
            }

            if (!Uri.IsWellFormedUriString(arg, UriKind.RelativeOrAbsolute))
            {
                throw new ArgumentException("Podana ścieżka jest niepoprawna");
            }

            return arg;
        }

        private string ParseDestination(string arg)
        {
            if (!Uri.IsWellFormedUriString(arg, UriKind.RelativeOrAbsolute))
            {
                throw new ArgumentException("Podana ścieżka jest niepoprawna");
            }

            return arg;
        }
    }
}
