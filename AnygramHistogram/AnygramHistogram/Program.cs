using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AnygramProcessor;

namespace AnygramHistogram
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                ShowUsage();
                return;
            }

            int numberOfWords;

            if (!int.TryParse(args[1], NumberStyles.Integer, NumberFormatInfo.CurrentInfo, out numberOfWords))
            {
                throw new ArgumentException("Invalid number passed for number of words.");   
            }

            var fileLoader = new FileLoader(args[0]);
            var fileData = fileLoader.Read().Trim();
            if (string.IsNullOrEmpty(fileData))
            {
                Console.WriteLine("Source file is blank. Please provide a valid file.");
                return;
            }

            var parser = new AnygramParser(numberOfWords);
            var anygrams = parser.Parse(fileData);

            if (anygrams.Any())
            {
                PrintHistogram(parser.GetHistogram(anygrams));
            }
            else
            {
                Console.WriteLine("Source file has insufficient number of words to generate a bigram.");  
            }
        }

        private static void PrintHistogram(IEnumerable<string> histograms)
        {
            Console.WriteLine("The bigrams with their counts are: ");
            histograms.ToList().ForEach(Console.WriteLine);
        }

        private static void ShowUsage()
        {
            Console.WriteLine("{0}", @"To run this application please use the following syntax: BigramHistogram [SourceFilePath] [NumberOfWordsToParse]");
        }
    }
}
