using System;
using System.Collections.Generic;
using System.Linq;
using AnygramProcessor.Extensions;
using AnygramProcessor.Interfaces;

namespace AnygramProcessor
{
    /// <summary>
    /// Parser class for "N"grams.
    /// </summary>
    public class AnygramParser : IAnyGramParser
    {
        public int NumberOfWords { get; set; }

        public AnygramParser(int numberOfWords)
        {
            NumberOfWords = numberOfWords;
        }
        
        public IList<Anygram> Parse(string input)
        {
            var anygrams = new List<Anygram>();
            var words = input.RemovePunctuation().Trim().Split((char[])null, StringSplitOptions.RemoveEmptyEntries).ToArray();

            for (var i = 0; i < words.Length - (NumberOfWords - 1); i++)
            {
                anygrams.Add(GetAnygram(words, i));
            }

            return anygrams;
        }

        private Anygram GetAnygram(IList<string> wordList, int index)
        {
            var anygram = new List<string>();
            for (var i = 0; i < NumberOfWords; i++)
            {
                anygram.Add(wordList[index + i].ToLower());
            }

            return new Anygram(anygram);
        }

        public IList<string> GetHistogram(IEnumerable<Anygram> anygrams)
        {
            var histogramList = new List<string>();
            var histogram = GenerateHistogram(anygrams);

            foreach (var item in histogram)
            {
                var anygram = string.Join(" ", item.Key.Words.ToArray());
                histogramList.Add(string.Format("{0}: {1}", anygram, item.Value));
            }

            return histogramList;
        }

        public Dictionary<Anygram, int> GenerateHistogram(IEnumerable<Anygram> anygrams)
        {
            var histogram = new Dictionary<Anygram, int>();

            anygrams.ToList().ForEach(item =>
            {
                if (histogram.ContainsKey(item))
                {
                    histogram[item]++;
                }
                else
                {
                    histogram.Add(item, 1);
                }
            });

            return histogram;
        }
    }
}
